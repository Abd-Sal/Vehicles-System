namespace SellingRentingCarsSystem.API.Interfaces;

public interface IMaintenanceServices
{
    Task<Result<PaginatedList<FullMaintenanceResponse>>> GetMaintenancesForVehicleAsync(string vehicleID, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<MaintenanceResponse>> MaintenanceForVehicle(MaintenanceRequest maintenanceRequest, CancellationToken cancellationToken = default);
    Task<Result> PutVehicleInMaintenance(string vehicleID, int days, CancellationToken cancellationToken = default);
}
