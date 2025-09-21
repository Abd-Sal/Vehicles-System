namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperSellVehicleProfile : AutoMapper.Profile
{
    public AutoMapperSellVehicleProfile()
    {
        //SellVehicle
        SellVehicleMapping();
        SellVehicleResponseMapping();
    }

    //SellVehicle
    private void SellVehicleMapping()
        => CreateMap<SellVehicleRequest, SellVehicle>().ReverseMap();
    private void SellVehicleResponseMapping()
        => CreateMap<SellVehicle, SellVehicleResponse>().ReverseMap();
}
