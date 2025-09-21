namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsModelServices
{
    Task<Result<PaginatedList<ModelResponse>>> GetAllModels(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullModelResponse>>> GetAllFullModels(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FullModelResponse>> GetModelByID(string modelID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullModelResponse>>> GetModelsByMakeID(string makeID, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullModelResponse>>> GetModelsByName(string modelName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ModelResponse>> UpdateModel(string modelID, ModelRequest modelRequest, CancellationToken cancellationToken = default);
    Task<Result<ModelResponse>> AddModel(ModelRequest modelRequest, CancellationToken cancellationToken = default);

}
