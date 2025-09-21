namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperFuelDeliveryProfile : AutoMapper.Profile
{
    public AutoMapperFuelDeliveryProfile()
    {
        //FuelDelivery
        FuelDeliveryMapping();
        FuelDeliveryResponseMapping();
    }
    //FuelDelivery
    private void FuelDeliveryMapping()
        => CreateMap<FuelDeliveryRequest, FuelDelivery>();
    private void FuelDeliveryResponseMapping()
        => CreateMap<FuelDelivery, FuelDeliveryResponse>();
}
