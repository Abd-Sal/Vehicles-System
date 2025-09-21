namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperFuelDeliveryExtensions
{
    //FuelDelivery
    public static FuelDelivery ToFuelDelivery(this FuelDeliveryRequest fuelDeliveryRequest, IMapper mapper)
        => mapper.Map<FuelDelivery>(fuelDeliveryRequest);
    public static FuelDeliveryResponse ToFuelDeliveryResponse(this FuelDelivery fuelDelivery, IMapper mapper)
        => mapper.Map<FuelDeliveryResponse>(fuelDelivery);

}
