using SellingRentingCarsSystem.API.Models;

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

    public async Task<Result<PaginatedList<FullRentVehicleResponse>>> RentHistoryForVehicle
        (string vehicleID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<PaginatedList<FullRentVehicleResponse>>(VehicleErrors.NotFoundVehicle);

        var query = appDbContext.RentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
                .ThenInclude(x => x.Model)
                    .ThenInclude(x => x.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Where(x => x.VehicleID == vehicleID)
            .Select(x => new FullRentVehicleResponse(
                x.Id, new VehicleResponse(x.Vehicle.Id, x.Vehicle.VIN,
                new FullModelResponse(x.Vehicle.Model.Id, x.Vehicle.Model.Make.ToMakeResponse(mapper), x.Vehicle.Model.ModelName, x.Vehicle.Model.ProductionYear),
                x.Vehicle.AddDate, x.Vehicle.RangeMiles, x.Vehicle.InteriorColor, x.Vehicle.ExteriorColor, x.Vehicle.VehicleStatus,
                x.Vehicle.BodyType.ToBodyTypeResponse(mapper), x.Vehicle.TransmissionType.ToTransmissionTypeResponse(mapper),
                x.Vehicle.PassengerCount,
                new FullPowerTrainResponse(x.Vehicle.PowerTrain.Id, x.Vehicle.PowerTrain.PowerTrainType,
                x.Vehicle.PowerTrain.HorsePower, x.Vehicle.PowerTrain.Torque, x.Vehicle.PowerTrain.CombinedRangeMiles, x.Vehicle.PowerTrain.ElectricOnlyRangeMiles,
                x.Vehicle.PowerTrain.ChargePort != null ? x.Vehicle.PowerTrain.ChargePort.ToChargePortResponse(mapper) : null, x.Vehicle.PowerTrain.BatteryCapacityKWh,
                x.Vehicle.PowerTrain.FuelDelivery != null ? x.Vehicle.PowerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
                x.Vehicle.PowerTrain.FuleType != null ? x.Vehicle.PowerTrain.FuleType.ToFuelTypeResponse(mapper) : null,
                x.Vehicle.PowerTrain.Aspiration != null ? x.Vehicle.PowerTrain.Aspiration.ToAspirationResponse(mapper) : null,
                x.Vehicle.PowerTrain.EngineSize, x.Vehicle.PowerTrain.Cylinders), x.Vehicle.VehiclePrice), x.Customer.ToCustomerResponse(mapper),
                x.StartAtMile, x.EndAtMile != null ? (int)x.EndAtMile : 0, x.StartRentDate, x.ExpectedEndRentDate, x.ActualEndRentDate != null ? (DateTime)x.ActualEndRentDate : default(DateTime), x.ExpectedAmount,
                x.DamageAmount, x.DamageDescription, x.Amount != null ? (int)x.Amount : 0, x.PayLater, x.Payment!.ToPaymentResponse(mapper)));

        var result = await PaginatedList<FullRentVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

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

    public async Task<Result<PaginatedList<FullRentedVehicleResponse>>> CurrentRentingVehicle
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {

        var query = appDbContext.RentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
                .ThenInclude(x => x.Model)
                    .ThenInclude(x => x.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Where(x => !x.ActualEndRentDate.HasValue && x.Vehicle.VehicleStatus == VehiclesStatus.rent.ToString())
            .Select(x => new FullRentedVehicleResponse(
                x.Id, 
                new VehicleResponse(
                    x.Vehicle.Id,
                    x.Vehicle.VIN,
                    new FullModelResponse(
                            x.Vehicle.Model.Id,
                            x.Vehicle.Model.Make.ToMakeResponse(mapper),
                            x.Vehicle.Model.ModelName,
                            x.Vehicle.Model.ProductionYear
                            ),
                    x.Vehicle.AddDate,
                    x.Vehicle.RangeMiles,
                    x.Vehicle.InteriorColor,
                    x.Vehicle.ExteriorColor,
                    x.Vehicle.VehicleStatus,
                    x.Vehicle.BodyType.ToBodyTypeResponse(mapper),
                    x.Vehicle.TransmissionType.ToTransmissionTypeResponse(mapper),
                    x.Vehicle.PassengerCount,
            new FullPowerTrainResponse(
                        x.Vehicle.PowerTrain.Id,
                        x.Vehicle.PowerTrain.PowerTrainType,
                        x.Vehicle.PowerTrain.HorsePower,
                        x.Vehicle.PowerTrain.Torque,
                        x.Vehicle.PowerTrain.CombinedRangeMiles,
                        x.Vehicle.PowerTrain.ElectricOnlyRangeMiles,
                        x.Vehicle.PowerTrain.ChargePort != null ? x.Vehicle.PowerTrain.ChargePort.ToChargePortResponse(mapper) : null,
                        x.Vehicle.PowerTrain.BatteryCapacityKWh,
                        x.Vehicle.PowerTrain.FuelDelivery != null ? x.Vehicle.PowerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
                        x.Vehicle.PowerTrain.FuleType != null ? x.Vehicle.PowerTrain.FuleType.ToFuelTypeResponse(mapper) : null,
                        x.Vehicle.PowerTrain.Aspiration != null ? x.Vehicle.PowerTrain.Aspiration.ToAspirationResponse(mapper) : null,
                        x.Vehicle.PowerTrain.EngineSize,
                        x.Vehicle.PowerTrain.Cylinders
                        ),
                    x.Vehicle.VehiclePrice),
                x.Customer.ToCustomerResponse(mapper),
                x.StartRentDate,
                x.ExpectedEndRentDate,
                x.ExpectedAmount
            )).OrderByDescending(x => x.StartDate);

        var result = await PaginatedList<FullRentedVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FullRentVehicleResponse>>> VehicleEndRentToday
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {

        var query = appDbContext.RentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
                .ThenInclude(x => x.Model)
                    .ThenInclude(x => x.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Where(x => x.ExpectedEndRentDate.Date == DateTime.UtcNow.Date)
            .Select(x => new FullRentVehicleResponse(
                x.Id, new VehicleResponse(x.Vehicle.Id, x.Vehicle.VIN,
                new FullModelResponse(x.Vehicle.Model.Id, x.Vehicle.Model.Make.ToMakeResponse(mapper), x.Vehicle.Model.ModelName, x.Vehicle.Model.ProductionYear),
                x.Vehicle.AddDate, x.Vehicle.RangeMiles, x.Vehicle.InteriorColor, x.Vehicle.ExteriorColor, x.Vehicle.VehicleStatus,
                x.Vehicle.BodyType.ToBodyTypeResponse(mapper), x.Vehicle.TransmissionType.ToTransmissionTypeResponse(mapper),
                x.Vehicle.PassengerCount,
                new FullPowerTrainResponse(x.Vehicle.PowerTrain.Id, x.Vehicle.PowerTrain.PowerTrainType,
                x.Vehicle.PowerTrain.HorsePower, x.Vehicle.PowerTrain.Torque, x.Vehicle.PowerTrain.CombinedRangeMiles, x.Vehicle.PowerTrain.ElectricOnlyRangeMiles,
                x.Vehicle.PowerTrain.ChargePort != null ? x.Vehicle.PowerTrain.ChargePort.ToChargePortResponse(mapper) : null, x.Vehicle.PowerTrain.BatteryCapacityKWh,
                x.Vehicle.PowerTrain.FuelDelivery != null ? x.Vehicle.PowerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
                x.Vehicle.PowerTrain.FuleType != null ? x.Vehicle.PowerTrain.FuleType.ToFuelTypeResponse(mapper) : null,
                x.Vehicle.PowerTrain.Aspiration != null ? x.Vehicle.PowerTrain.Aspiration.ToAspirationResponse(mapper) : null,
                x.Vehicle.PowerTrain.EngineSize, x.Vehicle.PowerTrain.Cylinders), x.Vehicle.VehiclePrice), x.Customer.ToCustomerResponse(mapper),
                x.StartAtMile, x.EndAtMile != null ? (int)x.EndAtMile : 0, x.StartRentDate, x.ExpectedEndRentDate, x.ActualEndRentDate != null ? (DateTime)x.ActualEndRentDate : default(DateTime), x.ExpectedAmount,
                x.DamageAmount, x.DamageDescription, x.Amount != null ? (int)x.Amount : 0, x.PayLater, x.Payment!.ToPaymentResponse(mapper)))
                .OrderByDescending(x => x.StartRentDate);

        var result = await PaginatedList<FullRentVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }
}
