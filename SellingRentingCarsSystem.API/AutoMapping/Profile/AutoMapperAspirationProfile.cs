namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperAspirationProfile : AutoMapper.Profile
{
    public AutoMapperAspirationProfile()
    {
        //Aspiration
        AspirationMapping();
        AspirationResponseMapping();
    }

    //Aspiration
    private void AspirationMapping()
        => CreateMap<AspirationRequest, Aspiration>();
    private void AspirationResponseMapping()
        => CreateMap<Aspiration, AspirationResponse>();
}
