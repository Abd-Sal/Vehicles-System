namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperVehicleFeatureProfile : AutoMapper.Profile
{
    public AutoMapperVehicleFeatureProfile()
    {
        //VehicleFeature
        VehicleFeatureMapping();
        VehicleFeatureResponseMapping();
    }
    //VehicleFeature
    private void VehicleFeatureMapping()
        => CreateMap<VehicleFeatureRequest, VehicleFeature>().ReverseMap();
    private void VehicleFeatureResponseMapping()
        => CreateMap<VehicleFeature, VehicleFeatureResponse>().ReverseMap();
}
