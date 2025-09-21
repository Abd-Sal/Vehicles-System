namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsAspirationServices
{
    Task<Result<AspirationResponse>> AddAspiration(AspirationRequest aspirationRequest, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> UpdateAspirtaion(string aspirationID, AspirationRequest aspirationRequest, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<AspirationResponse>>> GetAllAspirations(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> GetAspirationByID(string aspirationID, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> GetAspirationByName(string aspirationName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<AspirationResponse>>> SearchAspirationsByName(string aspirationName, RequestFilters filters, CancellationToken cancellationToken = default);

}
