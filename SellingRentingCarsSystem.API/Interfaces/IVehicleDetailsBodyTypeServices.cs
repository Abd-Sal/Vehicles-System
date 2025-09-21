namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsBodyTypeServices
{
    Task<Result<PaginatedList<BodyTypeResponse>>> GetAllBodyTypes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<BodyTypeResponse>> GetBodyTypeByID(string bodyTypeID, CancellationToken cancellationToken = default);
    Task<Result<BodyTypeResponse>> GetBodyTypeByName(string bodyTypeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<BodyTypeResponse>>> SearchBodyTypesByName(string bodyTypeName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<BodyTypeResponse>> UpdateBodyType(string bodyTypeID, BodyTypeRequest bodyTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<BodyTypeResponse>> AddBodyType(BodyTypeRequest bodyTypeRequest, CancellationToken cancellationToken = default);

}
