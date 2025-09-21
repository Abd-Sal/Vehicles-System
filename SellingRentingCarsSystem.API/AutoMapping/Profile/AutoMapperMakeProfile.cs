namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperMakeProfile : AutoMapper.Profile
{
    public AutoMapperMakeProfile()
    {
        //Make
        MakeMapping();
        MakeResponseMapping();
    }
    //Make
    private void MakeMapping()
        => CreateMap<MakeRequest, Make>().ReverseMap();
    private void MakeResponseMapping()
        => CreateMap<Make, MakeResponse>().ReverseMap();
}
