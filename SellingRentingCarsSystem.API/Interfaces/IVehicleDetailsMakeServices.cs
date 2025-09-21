namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsMakeServices
{
    Task<Result<PaginatedList<MakeResponse>>> GetAllMakes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> GetMakeByID(string makeID, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> GetMakeByName(string makeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<MakeResponse>>> SearchMakesByName(string makeName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> UpdateMake(string makeID, MakeRequest makeRequest, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> AddMake(MakeRequest makeRequest, CancellationToken cancellationToken = default);

}
