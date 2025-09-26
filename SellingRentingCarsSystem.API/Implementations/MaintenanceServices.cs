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

    //TODO : review why we not move it to mapping extensions
    public async Task<Result<PaginatedList<FullMaintenanceResponse>>> GetMaintenancesForVehicleAsync
        (string vehicleID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<PaginatedList<FullMaintenanceResponse>>(VehicleErrors.NotFoundVehicle);

        var query = appDbContext.Maintenances
            .Where(x => x.VehicleID == vehicleID)
            .ToFullMaintenanceResponses(mapper)
            .OrderByDescending(x => x.DoneAt);

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
