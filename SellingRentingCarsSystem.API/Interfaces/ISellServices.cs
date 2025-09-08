namespace SellingRentingCarsSystem.API.Interfaces;

public interface ISellServices
{
    Task<Result<SellVehicleResponse>> SellVehicle(SellVehicleRequest sellVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> ReturnSelledVehicle(string sellVehicleID, CancellationToken cancellationToken = default);
    Task<Result<List<SellVehicleResponse>>> AllSelledVehicles(CancellationToken cancellationToken = default);
}
