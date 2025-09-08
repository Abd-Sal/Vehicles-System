namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleServices
{
    Task<Result<List<BriefVehicleResponse>>> GetAllVehicles(bool availableOnly = true, CancellationToken cancellationToken = default);
    Task<Result<List<BriefVehicleResponse>>> GetVehiclesByPowerTrainType(VehiclePowerTrainRequest vehiclePowerTrainRequest, bool availableOnly = true, CancellationToken cancellationToken = default);
    Task<Result<List<BriefVehicleResponse>>> GetVehiclesByPowerTrainID(string powerTrainID, bool availableOnly = true, CancellationToken cancellationToken = default);
    Task<Result<VehicleResponse>> GetVehicle(string vehicleID, bool availavle = true, CancellationToken cancellationToken = default);
    Task<Result<BriefVehicleResponse>> AddVehicle(VehicleRequest vehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<BriefVehicleResponse>> BuyVehicle(BuyVehicleRequest buyVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<BriefVehicleResponse>> AddFullVehicle(IVehicleRequest vehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> RemoveVehicle(string vehicleID, CancellationToken cancellationToken = default);
    Task<Result> UpdateVehicle(string vehicleID, VehicleRequest vehicleRequest, CancellationToken cancellationToken = default);
    Task<Result<VehicleStatusResponse>> StatusVehicle(string vehicleID, CancellationToken cancellationToken = default);
    Task<Result<List<BriefVehicleResponse>>> SearchForVehicle(string modelName, CancellationToken cancellationToken = default);
    Task<Result<List<BriefVehicleResponse>>> VehicleByStatus(VehicleStatusRequest vehicleStatusRequest, CancellationToken cancellationToken = default);
    Task<Result<VehicleFeatureResponse>> AddFeatureForVehicle(string vehicleID, VehicleFeatureRequest vehicleFeatureRequest, CancellationToken cancellationToken = default);
    Task<Result> RemoveFeatureForVehicle(string vehicleFeatureID, CancellationToken cancellationToken = default);
    Task<Result<List<TagResponse>>> SetTagsForVehicles(string vehicleID, List<TagRequest> tags, CancellationToken cancellationToken = default);
    Task<Result<List<FeatureResponse>>> GetFeaturesForVehicle(string vehicleID, CancellationToken cancellationToken = default);
    Task<Result<ImageResponse>> AddImageForVehicle(string vehicleID, ImageRequest imageRequest, CancellationToken cancellationToken = default);
    Task<Result> DeleteImageForVehicle(string vehicleID, string imageID, CancellationToken cancellationToken = default);
    Task<Result<List<ImageResponse>>> ImagesForVehicle(string vehicleID, CancellationToken cancellationToken = default);
    Task<Result<(string imagePath, string contentType)>> GetVehicleImage(string imageName, CancellationToken cancellationToken);
}
