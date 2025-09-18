namespace SellingRentingCarsSystem.API.Implementations;

public class MaintenanceServices(AppDbContext appDbContext, IMapper mapper,
    IPaymentServices paymentServices, IBookingServices bookingServices,
    ILogger<MaintenanceServices> logger) : IMaintenanceServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly IPaymentServices paymentServices = paymentServices;
    private readonly IBookingServices bookingServices = bookingServices;
    private readonly ILogger<MaintenanceServices> logger = logger;


    public async Task<Result<PaginatedList<FullMaintenanceResponse>>> GetMaintenancesForVehicleAsync
        (string vehicleID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<PaginatedList<FullMaintenanceResponse>>(VehicleErrors.NotFoundVehicle);

        var query = appDbContext.Maintenances.AsNoTracking()
            .Include(x => x.Payment)
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
            .Where(x => x.VehicleID == vehicleID)
            .Select(x => new FullMaintenanceResponse(
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
                                (x.Vehicle.PowerTrain.ChargePort != null ? x.Vehicle.PowerTrain.ChargePort.ToChargePortResponse(mapper) : null),
                                x.Vehicle.PowerTrain.BatteryCapacityKWh,
                                (x.Vehicle.PowerTrain.FuelDelivery != null ? x.Vehicle.PowerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null),
                                (x.Vehicle.PowerTrain.FuleType != null ? x.Vehicle.PowerTrain.FuleType.ToFuelTypeResponse(mapper) : null),
                                (x.Vehicle.PowerTrain.Aspiration != null ? x.Vehicle.PowerTrain.Aspiration.ToAspirationResponse(mapper) : null),
                                x.Vehicle.PowerTrain.EngineSize,
                                x.Vehicle.PowerTrain.Cylinders
                            ),
                    x.Vehicle.VehiclePrice
                ),
                x.Title,
                x.Description,
                x.Payment.ToPaymentResponse(mapper),
                x.DoneAt
            )).OrderByDescending(x => x.DoneAt);

        var result = await PaginatedList<FullMaintenanceResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);

    }

    public async Task<Result<MaintenanceResponse>> MaintenanceForVehicle
        (MaintenanceRequest maintenanceRequest, CancellationToken cancellationToken = default)
    {
        if (maintenanceRequest is null)
            return Result.Failure<MaintenanceResponse>(VehicleDetailsErrors.NullMaintenance);

        if (maintenanceRequest.Payment is null)
            return Result.Failure<MaintenanceResponse>(PaymentErrors.NullPayment);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == maintenanceRequest.VehicleID, cancellationToken)))
            return Result.Failure<MaintenanceResponse>(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == maintenanceRequest.VehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<MaintenanceResponse>(VehicleErrors.UnavailableVehicle);

        Maintenance? maintenance = null;
        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            maintenance = maintenanceRequest.ToMaintenance(mapper);

            var doPayment = await paymentServices.DoPayment(maintenanceRequest.Payment, cancellationToken);
            if (doPayment.IsFailure)
                return Result.Failure<MaintenanceResponse>(doPayment.Error);

            await appDbContext.Maintenances.AddAsync(maintenance, cancellationToken);
            await appDbContext.Vehicles.Where(x => x.Id == maintenance.VehicleID)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.VehicleStatus, VehiclesStatus.available.ToString()),
                    cancellationToken
                );
            await appDbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("user finish maintenance for vehicle:(ID:{vehicleID})", maintenanceRequest.VehicleID);
        }
        if(maintenance is not null)
            return Result.Success(maintenance.ToMaintenanceResponse(mapper));
        return Result.Failure<MaintenanceResponse>(GeneralErrors.UnexpectedError("Finish Maintenance For Vehicle"));
    }

    public async Task<Result> PutVehicleInMaintenance
        (string vehicleID, int days, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Vehicles.FindAsync(vehicleID, cancellationToken) is not { } vehicle)
            return Result.Failure(VehicleErrors.NotFoundVehicle);

        if (vehicle.VehicleStatus != VehiclesStatus.available.ToString())
            return Result.Failure(VehicleErrors.UnavailableVehicle);

        var date = DateTime.UtcNow;
        var checkDate = new CheckBookingDateRequest(vehicleID, date, date.AddDays(days));

        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            var cancelBooks = await bookingServices.CancelBookingForVehicleInRangeDate(checkDate, cancellationToken);
            if (cancelBooks.IsFailure)
                return Result.Failure(cancelBooks.Error);

            await appDbContext.Vehicles.Where(x => x.Id == vehicleID)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(x => x.VehicleStatus, VehiclesStatus.maintenance.ToString()),
                    cancellationToken
                );

            logger.LogInformation("user put vehicle:(ID:{vehicleID}) in maintenance", vehicleID);
        }
        return Result.Success();
    }
}
