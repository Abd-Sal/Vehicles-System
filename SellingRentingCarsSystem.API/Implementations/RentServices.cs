namespace SellingRentingCarsSystem.API.Implementations;

public class RentServices(AppDbContext appDbContext, IMapper mapper,
    IBookingServices bookingServices, IPaymentServices paymentServices,
    INotificationSender notificationSender, ILogger<RentServices> logger) : IRentServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly IBookingServices bookingServices = bookingServices;
    private readonly IPaymentServices paymentServices = paymentServices;
    private readonly INotificationSender notificationSender = notificationSender;
    private readonly ILogger<RentServices> logger = logger;

    public async Task<Result<List<RentVehicleResponse>>> RentHistoryForVehicle
        (string vehicleID, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<List<RentVehicleResponse>>(VehicleErrors.NotFoundVehicle);

        var result = (await appDbContext.RentVehicles.AsNoTracking()
            .Where(x => x.VehicleID == vehicleID)
            .ToListAsync(cancellationToken))
            .ToRentVehicleResponses(mapper);

        return Result.Success(result);
    }

    public async Task<Result<RentVehicleResponse>> StartRentVehicle
        (RentVehicleRequest rentVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (rentVehicleRequest is null)
            return Result.Failure<RentVehicleResponse>(RentVehicleErrors.NullRentVehicle);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == rentVehicleRequest.VehicleID, cancellationToken)))
            return Result.Failure<RentVehicleResponse>(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == rentVehicleRequest.VehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<RentVehicleResponse>(VehicleErrors.UnavailableVehicle);
        
        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == rentVehicleRequest.CustomerID, cancellationToken)))
            return Result.Failure<RentVehicleResponse>(CustomerErrors.NotFoundCustomer);

        var checkBookDateRequest = new CheckBookingDateRequest(rentVehicleRequest.VehicleID, DateTime.UtcNow, rentVehicleRequest.ExpectedEndRentDate);
        var checkResult = await bookingServices.CheckBooksForVehicleInRangeDate(checkBookDateRequest, cancellationToken);
        if (checkResult.IsFailure)
            return Result.Failure<RentVehicleResponse>(checkResult.Error);

        if (!checkResult.Value)
            return Result.Failure<RentVehicleResponse>(VehicleErrors.BookedVehicle);

        RentVehicle? rentVehicle = null;
        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            rentVehicle = rentVehicleRequest.ToRentVehicle(mapper);
            rentVehicle.StartAtMile = (await appDbContext.Vehicles.FindAsync(rentVehicleRequest.VehicleID, cancellationToken))!.RangeMiles;
            await appDbContext.RentVehicles.AddAsync(rentVehicle, cancellationToken);

            if (!rentVehicleRequest.PayLater)
            {
                if (rentVehicleRequest.Payment is null)
                    return Result.Failure<RentVehicleResponse>(RentVehicleErrors.NullRentVehicle);

                var doPayment = await paymentServices.DoPayment(rentVehicleRequest.Payment, cancellationToken);
                if (doPayment.IsFailure)
                    return Result.Failure<RentVehicleResponse>(doPayment.Error);

                await appDbContext.RentVehicles.Where(x => x.Id == rentVehicle.Id)
                    .ExecuteUpdateAsync(setters =>
                        setters
                            .SetProperty(x => x.PaymentID, doPayment.Value.Id),
                        cancellationToken
                    );
            }
            await appDbContext.Vehicles.Where(x => x.Id == rentVehicleRequest.VehicleID)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.VehicleStatus, VehiclesStatus.rent.ToString()),
                    cancellationToken
                );

            var customer = await appDbContext.Customers.FindAsync(rentVehicleRequest.CustomerID, cancellationToken);
            if(customer?.Email is not null)
            {
                var vehicle = await appDbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Make).SingleAsync(x => x.Id == rentVehicleRequest.VehicleID, cancellationToken);
                notificationSender.SendEmailAsync(customer.Email, ConstantStrings.SubjectForStartRenting, ConstantStrings.BodyForStartRenting(customer, vehicle, rentVehicle));

            }

            await appDbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("rent is started for vehicle:(ID:{vehicleID})", rentVehicleRequest.VehicleID);
        }

        if(rentVehicle is not null)
            return Result.Success(rentVehicle.ToRentVehicleResponse(mapper));
        return Result.Failure<RentVehicleResponse>(GeneralErrors.UnexpectedError("Error In Start Renting Vehicle"));
    }

    public async Task<Result<RentVehicleResponse>> StopRentVehicle
        (StopRentVehicleRequest stopRentVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.RentVehicles.FindAsync(stopRentVehicleRequest.Id) is not { } rentVehicle)
            return Result.Failure<RentVehicleResponse>(RentVehicleErrors.NotFoundRentVehicle);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == stopRentVehicleRequest.VehicleID, cancellationToken)))
            return Result.Failure<RentVehicleResponse>(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == stopRentVehicleRequest.VehicleID &&
            x.VehicleStatus != VehiclesStatus.rent.ToString(), cancellationToken))
            return Result.Failure<RentVehicleResponse>(VehicleErrors.UnavailableVehicle);

        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == stopRentVehicleRequest.CustomerID, cancellationToken)))
            return Result.Failure<RentVehicleResponse>(CustomerErrors.NotFoundCustomer);

        if (stopRentVehicleRequest.Payment is null && string.IsNullOrEmpty(rentVehicle.PaymentID))
            return Result.Failure<RentVehicleResponse>(PaymentErrors.NullPayment);

        if (stopRentVehicleRequest.Payment is not null && !(string.IsNullOrEmpty(rentVehicle.PaymentID)))
            return Result.Failure<RentVehicleResponse>(RentVehicleErrors.DuplicatedPaidRentVehicle);

        if (rentVehicle.VehicleID != stopRentVehicleRequest.VehicleID ||
            rentVehicle.CustomerID != stopRentVehicleRequest.CustomerID)
            return Result.Failure<RentVehicleResponse>(RentVehicleErrors.WrongDetailsRentVehicle);


        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            var paymentID = rentVehicle.PaymentID;
            if(stopRentVehicleRequest.Payment is not null)
            {
                var payment = await paymentServices.DoPayment(stopRentVehicleRequest.Payment);
                if (payment.IsFailure)
                    return Result.Failure<RentVehicleResponse>(payment.Error);
                paymentID = payment.Value.Id;
            }

            var rent = stopRentVehicleRequest.ToRentVehicle(mapper);
            await appDbContext.RentVehicles.Where(x => x.Id == stopRentVehicleRequest.Id)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.EndAtMile, rent.EndAtMile)
                        .SetProperty(x => x.ActualEndRentDate, rent.ActualEndRentDate)
                        .SetProperty(x => x.DamageAmount, rent.DamageAmount)
                        .SetProperty(x => x.DamageDescription, rent.DamageDescription)
                        .SetProperty(x => x.Amount, rent.Amount)
                        .SetProperty(x => x.PaymentID, paymentID),
                    cancellationToken
                );

            await appDbContext.Vehicles.Where(x => x.Id == rentVehicle.VehicleID)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.VehicleStatus, VehiclesStatus.available.ToString())
                        .SetProperty(x => x.RangeMiles, stopRentVehicleRequest.EndMile),
                    cancellationToken
                );


            var customer = await appDbContext.Customers.FindAsync(stopRentVehicleRequest.CustomerID, cancellationToken);
            if(customer?.Email is not null)
            {
                var vehicle = await appDbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Make).SingleAsync(x => x.Id == stopRentVehicleRequest.VehicleID, cancellationToken);
                notificationSender.SendEmailAsync(customer.Email, ConstantStrings.SubjectForStopRenting, ConstantStrings.BodyForStopRenting(customer, vehicle, rentVehicle));
            }

            await appDbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("rent is stopped for vehicle:(ID:{vehicleID})", stopRentVehicleRequest.VehicleID);

        }

        return Result.Success(rentVehicle.ToRentVehicleResponse(mapper));
    }

    public async Task<Result<PaginatedList<RentedVehicleResponse>>> CurrentRentingVehicle
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.RentVehicles.AsNoTracking()
            .Include(x => x.Vehicle)
                .ThenInclude(x => x.Model)
                    .ThenInclude(x => x.Make)
            .Where(x => !x.ActualEndRentDate.HasValue && x.Vehicle.VehicleStatus == VehiclesStatus.rent.ToString())
            .Select(x => new RentedVehicleResponse(x.Id, x.VehicleID, x.CustomerID,
            $"{x.Vehicle.Model.Make.MakeName} {x.Vehicle.Model.ModelName} {x.Vehicle.Model.ProductionYear}",
                x.StartRentDate, x.ExpectedEndRentDate, x.ExpectedAmount));

        var result = await PaginatedList<RentedVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<List<BriefVehicleResponse>>> VehicleEndRentToday
        (CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.RentVehicles.AsNoTracking()
            .Include(x => x.Vehicle)
            .Where(x => x.ExpectedEndRentDate.Date == DateTime.UtcNow.Date)
            .OrderByDescending(x => x.StartRentDate)
            .Select(x => x.Vehicle)
            .ToListAsync(cancellationToken))
            .ToBriefVehicleResponses(mapper);

        return Result.Success(result);
    }
}
