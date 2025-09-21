namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsFeatureServices
{
    Task<Result<PaginatedList<FeatureResponse>>> GetAllFeatures(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> GetFeatureByID(string featureID, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> GetFeatureByName(string featureName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FeatureResponse>>> SearchFeaturesByName(string featureName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> UpdateFeature(string featureID, FeatureRequest featureRequest, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> AddFeature(FeatureRequest featureRequest, CancellationToken cancellationToken = default);
}
