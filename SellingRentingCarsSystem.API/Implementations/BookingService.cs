namespace SellingRentingCarsSystem.API.Implementations;

public class BookingService(AppDbContext appDbContext, IMapper mapper,
    INotificationSender notificationSender, ILogger<BookingService> logger) : IBookingServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly INotificationSender notificationSender = notificationSender;
    private readonly ILogger<BookingService> logger = logger;

    public async Task<Result<BookingVehicleResponse>> BookingVehicle
        (BookingVehicleRequest bookingVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (bookingVehicleRequest is null)
            return Result.Failure<BookingVehicleResponse>(BookingErrors.NullBooking);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == bookingVehicleRequest.VehicleID, cancellationToken)))
            return Result.Failure<BookingVehicleResponse>(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == bookingVehicleRequest.VehicleID && 
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<BookingVehicleResponse>(VehicleErrors.NotFoundVehicle);

        if(!(await appDbContext.Customers.AnyAsync(x => x.Id == bookingVehicleRequest.CustomerID, cancellationToken)))
            return Result.Failure<BookingVehicleResponse>(CustomerErrors.NotFoundCustomer);

        if (bookingVehicleRequest.StartDate >= DateTime.UtcNow.AddMonths(1))
            return Result.Failure<BookingVehicleResponse>(BookingErrors.TooLateStartDate(DateTime.UtcNow.Date));

        var checkRentDateRequest = new CheckBookingDateRequest(bookingVehicleRequest.VehicleID, bookingVehicleRequest.StartDate, bookingVehicleRequest.EndDate);
        var checkRentDate = await CheckBooksForVehicleInRangeDate(checkRentDateRequest, cancellationToken);
        if (checkRentDate.IsFailure)
            return Result.Failure<BookingVehicleResponse>(checkRentDate.Error);

        if (!checkRentDate.Value)
            return Result.Failure<BookingVehicleResponse>(VehicleErrors.BookedVehicle);

        var book = bookingVehicleRequest.ToBookingVehicle(mapper);
        await appDbContext.Bookings.AddAsync(book, cancellationToken);

        var customer = await appDbContext.Customers.FindAsync(bookingVehicleRequest.CustomerID, cancellationToken);
        if(customer?.Email is not null)
        {
            var vehicle = await appDbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Make).SingleAsync(x => x.Id == bookingVehicleRequest.VehicleID, cancellationToken);
            notificationSender.SendEmailAsync(customer.Email, ConstantStrings.SubjectForBooking, ConstantStrings.BodyForBooking(customer, vehicle, book));
        }

        await appDbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("user booking vehicle:({vehicleID}) for Customer:({customerID})", book.VehicleID, book.CustomerID);

        return Result.Success(book.ToBookingResponse(mapper));
    }

    public async Task<Result<PaginatedList<FullBookingVehicleResponse>>> GetBooksForVehicleInRangeDate
        (CheckBookingDateRequest checkBookingDateRequest, bool isCanceled, bool isDone, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == checkBookingDateRequest.VehicleID, cancellationToken)))
            return Result.Failure<PaginatedList<FullBookingVehicleResponse>>(VehicleErrors.NotFoundVehicle);

        var query = appDbContext.Bookings.AsNoTracking()
            .Where(x => x.StartDate < checkBookingDateRequest.EndDate &&
                        x.EndDate > checkBookingDateRequest.StartDate &&
                        (isCanceled ? !x.Canceled : true) &&
                        (isDone ? !x.Done : true))
            .ToFullBookingResponse(mapper)
            .OrderByDescending(x => x.StartDate);

        var result = await PaginatedList<FullBookingVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<bool>> CheckBooksForVehicleInRangeDate
        (CheckBookingDateRequest checkBookingDateRequest, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == checkBookingDateRequest.VehicleID, cancellationToken)))
            return Result.Failure<bool>(VehicleErrors.NotFoundVehicle);

        var result = await appDbContext.Bookings.AsNoTracking()
           .AsNoTracking()
            .Where(x => x.StartDate < checkBookingDateRequest.EndDate &&
                        x.EndDate > checkBookingDateRequest.StartDate &&
                        !x.Canceled)
            .AnyAsync(cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result> CancelBookingVehicle
        (string bookingVehicleID, CancellationToken cancellationToken = default)
    {
        if(await appDbContext.Bookings.SingleOrDefaultAsync(x => x.Id == bookingVehicleID, cancellationToken) is not { } book)
            return Result.Failure(BookingErrors.NotFoundBooking);

        await appDbContext.Bookings.Where(x => x.Id == bookingVehicleID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.Canceled, true),
                cancellationToken
            );

        var customer = await appDbContext.Customers.FindAsync(book.CustomerID, cancellationToken);
        if(customer?.Email is not null)
        {
            var vehicle = await appDbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Make).SingleAsync(x => x.Id == book.VehicleID, cancellationToken);
            var sendNotification = notificationSender
                .SendEmailAsync(customer.Email, ConstantStrings.SubjectForCancelBooking, ConstantStrings.BodyForCancelBooking(customer!, vehicle));
        }

        logger.LogInformation("user cancel booking vehicle:({vehicleID}) for Customer:({customerID})", book.VehicleID, book.CustomerID);

        return Result.Success();
    }

    public async Task<Result> UpdateBookingVehicle
        (string bookingVehicleID, UpdateBookingVehicleRequest updateBookingVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (updateBookingVehicleRequest is null)
            return Result.Failure(BookingErrors.NullBooking);

        if (await appDbContext.Bookings.FindAsync(bookingVehicleID, cancellationToken) is not { } booking)
            return Result.Failure(BookingErrors.NotFoundBooking);

        if (booking.Canceled)
            return Result.Failure(BookingErrors.CanceledBooking);

        var checkBookingDateRequest = new CheckBookingDateRequest(booking.VehicleID, updateBookingVehicleRequest.StartDate, updateBookingVehicleRequest.EndDate);
        var checkBookingDate = await CheckBooksForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);
        if (checkBookingDate.IsFailure)
            return Result.Failure(checkBookingDate.Error);

        if (!checkBookingDate.Value)
            return Result.Failure(VehicleErrors.BookedVehicle);

        await appDbContext.Bookings.Where(x => x.Id == bookingVehicleID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.StartDate, updateBookingVehicleRequest.StartDate)
                    .SetProperty(x => x.EndDate, updateBookingVehicleRequest.EndDate)
                    .SetProperty(x => x.ExpectedAmount, updateBookingVehicleRequest.ExpectedAmount),
                cancellationToken
            );

        var customer = await appDbContext.Customers.FindAsync(booking.CustomerID, cancellationToken);
        if(customer?.Email is not null)
        {
            var vehicle = await appDbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Make).SingleAsync(x => x.Id == booking.VehicleID, cancellationToken);
            notificationSender.SendEmailAsync(customer.Email, ConstantStrings.SubjectForUpdateBooking, ConstantStrings.BodyForUpdateBooking(customer, vehicle, updateBookingVehicleRequest));
        }

        logger.LogInformation("user update booking vehicle:({vehicleID}) for Customer:({customerID})", booking.VehicleID, booking.CustomerID);

        return Result.Success();
    }

    public async Task<Result<PaginatedList<FullBookingVehicleResponse>>> VehicleBooking
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Bookings.AsNoTracking()
            .ToFullBookingResponse(mapper)
            .OrderByDescending(x => x.EndDate);

        var result = await PaginatedList<FullBookingVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }
    
    public async Task<Result> CancelBookingForVehicleInRangeDate
        (CheckBookingDateRequest checkBookingDateRequest, CancellationToken cancellationToken = default)
    {
        var books = await GetBooksForVehicleInRangeDate(checkBookingDateRequest, true, true, cancellationToken);
        if (books.IsFailure)
            return Result.Failure(books.Error);
        if (!books.Value.Any())
            return Result.Success();
        foreach (var book in books.Value)
        {
            var cancelBook = await CancelBookingVehicle(book.Id, cancellationToken);
            if (cancelBook.IsFailure)
                return Result.Failure(cancelBook.Error);
        }
        return Result.Success();
    }

    //private methods
    public async Task<Result<List<FullBookingVehicleResponse>>> GetBooksForVehicleInRangeDate
        (CheckBookingDateRequest checkBookingDateRequest, bool isCanceled, bool isDone, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == checkBookingDateRequest.VehicleID, cancellationToken)))
            return Result.Failure<List<FullBookingVehicleResponse>>(VehicleErrors.NotFoundVehicle);

        var query = await appDbContext.Bookings.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Where(x => x.StartDate < checkBookingDateRequest.EndDate &&
                        x.EndDate > checkBookingDateRequest.StartDate &&
                        (isCanceled ? !x.Canceled : true) &&
                        (isDone ? !x.Done : true))
            .Select(x => new FullBookingVehicleResponse(
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
                    x.Vehicle.VehiclePrice
                ),
                x.Customer.ToCustomerResponse(mapper),
                x.StartDate,
                x.EndDate,
                x.ExpectedAmount
            )).OrderByDescending(x => x.StartDate)
            .ToListAsync(cancellationToken);
        return Result.Success(query);
    }
}
