namespace SellingRentingCarsSystem.API.Interfaces;

public interface IRentServices
{
    Task<Result<RentVehicleResponse>> StartRentVehicle(RentVehicleRequest rentVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<RentVehicleResponse>> StopRentVehicle(StopRentVehicleRequest stopRentVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullRentVehicleResponse>>> RentHistoryForVehicle(string vehicleID, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullRentedVehicleResponse>>> CurrentRentingVehicle(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullRentVehicleResponse>>> VehicleEndRentToday(RequestFilters filters, CancellationToken cancellationToken = default);

}
