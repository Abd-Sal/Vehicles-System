namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperVehicleFeatureExtensions
{
    //VehicleFeature
    public static VehicleFeature ToVehicleFeature(this VehicleFeatureRequest vehicleFeatureRequest, IMapper mapper)
        => mapper.Map<VehicleFeature>(vehicleFeatureRequest);
    public static VehicleFeatureResponse ToVehicleFeatureResponse(this VehicleFeature vehicleFeature, IMapper mapper)
        => mapper.Map<VehicleFeatureResponse>(vehicleFeature);
}
