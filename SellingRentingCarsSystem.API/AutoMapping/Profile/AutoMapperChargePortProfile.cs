namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperChargePortProfile : AutoMapper.Profile
{
    public AutoMapperChargePortProfile()
    {
        //ChargePort
        ChargePortMapping();
        ChargePortResponseMapping();
    }

    //ChargePort
    private void ChargePortMapping()
        => CreateMap<ChargePortRequest, ChargePort>();
    private void ChargePortResponseMapping()
        => CreateMap<ChargePort, ChargePortResponse>();
}

