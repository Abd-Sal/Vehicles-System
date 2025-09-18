namespace SellingRentingCarsSystem.API.Implementations;

public class SellServices(AppDbContext appDbContext, IMapper mapper,
    IPaymentServices paymentServices, IBookingServices bookingServices,
    ILogger<SellServices> logger) : ISellServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly IPaymentServices paymentServices = paymentServices;
    private readonly IBookingServices bookingServices = bookingServices;
    private readonly ILogger<SellServices> logger = logger;

    public async Task<Result<PaginatedList<FullSellVehicleResponse>>> AllSelledVehicles
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {

        var query = appDbContext.SellVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
                .ThenInclude(x => x.BodyType)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullSellVehicleResponse(
                x.Id, new VehicleResponse(x.Vehicle.Id, x.Vehicle.VIN, new FullModelResponse(x.Vehicle.Model.Id,
                x.Vehicle.Model.Make.ToMakeResponse(mapper), x.Vehicle.Model.ModelName, x.Vehicle.Model.ProductionYear),
                x.Vehicle.AddDate, x.Vehicle.RangeMiles, x.Vehicle.InteriorColor, x.Vehicle.ExteriorColor, x.Vehicle.VehicleStatus,
                x.Vehicle.BodyType.ToBodyTypeResponse(mapper), x.Vehicle.TransmissionType.ToTransmissionTypeResponse(mapper),
                x.Vehicle.PassengerCount, new FullPowerTrainResponse(x.Vehicle.PowerTrain.Id, x.Vehicle.PowerTrain.PowerTrainType,
                x.Vehicle.PowerTrain.HorsePower, x.Vehicle.PowerTrain.Torque, x.Vehicle.PowerTrain.CombinedRangeMiles, x.Vehicle.PowerTrain.ElectricOnlyRangeMiles,
                x.Vehicle.PowerTrain.ChargePort != null ? x.Vehicle.PowerTrain.ChargePort.ToChargePortResponse(mapper) : null,
                x.Vehicle.PowerTrain.BatteryCapacityKWh,
                x.Vehicle.PowerTrain.FuelDelivery != null ? x.Vehicle.PowerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
                x.Vehicle.PowerTrain.FuleType != null ? x.Vehicle.PowerTrain.FuleType.ToFuelTypeResponse(mapper) : null,
                x.Vehicle.PowerTrain.Aspiration != null ? x.Vehicle.PowerTrain.Aspiration.ToAspirationResponse(mapper) : null,
                x.Vehicle.PowerTrain.EngineSize, x.Vehicle.PowerTrain.Cylinders), x.Vehicle.VehiclePrice),
                x.Customer.ToCustomerResponse(mapper), x.SellDate, x.Payment.ToPaymentResponse(mapper)
            )).OrderByDescending(x => x.SellDate);

        var result = await PaginatedList<FullSellVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);
        
        return Result.Success(result);
    }

    public async Task<Result> ReturnSelledVehicle
        (string sellVehicleID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.SellVehicles.FindAsync(sellVehicleID, cancellationToken) is not { } sellVehicle)
            return Result.Failure(SellVehicleErrors.NotFoundSellVehicle);
        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            var removePayment = await paymentServices.RemovePayment(sellVehicle.PaymentID, cancellationToken);
            if (removePayment.IsFailure)
                return Result.Failure(removePayment.Error);

            await appDbContext.Vehicles.Where(x => x.Id == sellVehicle.VehicleID)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.VehicleStatus, VehiclesStatus.available.ToString()),
                    cancellationToken
                );

            await appDbContext.SellVehicles.Where(x => x.Id == sellVehicleID)
                .ExecuteDeleteAsync(cancellationToken);

            await appDbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("vehicle:(ID:{vehicleID}) is returned", sellVehicle.VehicleID);
        }

        return Result.Success();
    }

    public async Task<Result<SellVehicleResponse>> SellVehicle
        (SellVehicleRequest sellVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (sellVehicleRequest is null)
            return Result.Failure<SellVehicleResponse>(SellVehicleErrors.NullSellVehicle);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == sellVehicleRequest.VehicleID, cancellationToken)))
            return Result.Failure<SellVehicleResponse>(VehicleErrors.NotFoundVehicle);
        
        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == sellVehicleRequest.VehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<SellVehicleResponse>(VehicleErrors.UnavailableVehicle);

        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == sellVehicleRequest.CustomerID, cancellationToken)))
            return Result.Failure<SellVehicleResponse>(CustomerErrors.NotFoundCustomer);

        SellVehicle? sellVehicle = null;
        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            var payment = await paymentServices.DoPayment(sellVehicleRequest.Payment);
            if (payment.IsFailure)
                return Result.Failure<SellVehicleResponse>(payment.Error);

            sellVehicle = sellVehicleRequest.ToSellVehicle(mapper);
            sellVehicle.PaymentID = payment.Value.Id;
            await appDbContext.SellVehicles.AddAsync(sellVehicle, cancellationToken);

            await appDbContext.Vehicles.Where(x => x.Id == sellVehicle.VehicleID)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.VehicleStatus, VehiclesStatus.sold.ToString()),
                    cancellationToken
                );

            var date = DateTime.UtcNow;
            var checkBookingDateRequest = new CheckBookingDateRequest(sellVehicleRequest.VehicleID, date, date.AddYears(1));
            var cancelBooks = await bookingServices.CancelBookingForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);

            await appDbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("vehicle:(ID:{vehicleID}) is sold", sellVehicleRequest.VehicleID);

        }
        if(sellVehicle is not null)
            return Result.Success(sellVehicle.ToSellVehicleResponse(mapper));
        return Result.Failure<SellVehicleResponse>(GeneralErrors.UnexpectedError("Error In Sell Vehicle"));
    }

}
