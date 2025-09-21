namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperChargePortExtensions
{
    //ChargePort
    public static ChargePort ToChargePort(this ChargePortRequest chargePortRequest, IMapper mapper)
    => mapper.Map<ChargePort>(chargePortRequest);
    public static ChargePortResponse ToChargePortResponse(this ChargePort chargePort, IMapper mapper)
        => mapper.Map<ChargePortResponse>(chargePort);
}


