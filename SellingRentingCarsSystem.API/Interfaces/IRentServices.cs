namespace SellingRentingCarsSystem.API.Interfaces;

public interface IRentServices
{
    Task<Result<RentVehicleResponse>> StartRentVehicle(RentVehicleRequest rentVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<RentVehicleResponse>> StopRentVehicle(StopRentVehicleRequest stopRentVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<List<RentVehicleResponse>>> RentHistoryForVehicle(string vehicleID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<RentedVehicleResponse>>> CurrentRentingVehicle(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<List<BriefVehicleResponse>>> VehicleEndRentToday(CancellationToken cancellationToken = default);
}
