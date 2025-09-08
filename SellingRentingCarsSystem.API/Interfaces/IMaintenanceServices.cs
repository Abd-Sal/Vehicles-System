namespace SellingRentingCarsSystem.API.Interfaces;

public interface IMaintenanceServices
{
    Task<Result<List<MaintenanceResponse>>> GetMaintenancesForVehicleAsync(string vehicleID, CancellationToken cancellationToken = default);
    Task<Result<MaintenanceResponse>> MaintenanceForVehicle(MaintenanceRequest maintenanceRequest, CancellationToken cancellationToken = default);
    Task<Result> PutVehicleInMaintenance(string vehicleID, int days, CancellationToken cancellationToken = default);
}
