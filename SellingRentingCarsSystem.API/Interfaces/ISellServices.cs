namespace SellingRentingCarsSystem.API.Interfaces;

public interface ISellServices
{
    Task<Result<SellVehicleResponse>> SellVehicle(SellVehicleRequest sellVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> ReturnSelledVehicle(string sellVehicleID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullSellVehicleResponse>>> AllSelledVehicles(RequestFilters filters, CancellationToken cancellationToken = default);
}
