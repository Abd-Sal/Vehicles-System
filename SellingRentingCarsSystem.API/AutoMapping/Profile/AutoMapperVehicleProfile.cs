namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperVehicleProfile : AutoMapper.Profile
{
    public AutoMapperVehicleProfile()
    {
        //Vehicle
        VehicleMapping();
        VehicleResponseMapping();
    }
    //Vehicle
    private void VehicleMapping()
        => CreateMap<VehicleRequest, Vehicle>().ReverseMap();
    private void VehicleResponseMapping()
        => CreateMap<Vehicle, BriefVehicleResponse>().ReverseMap();
}
