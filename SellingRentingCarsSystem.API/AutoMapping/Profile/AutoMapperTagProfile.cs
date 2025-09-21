namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperTagProfile : AutoMapper.Profile
{
    public AutoMapperTagProfile()
    {
        //Tag
        TagResponseMapping();
    }

    //Tag
    private void TagResponseMapping()
        => CreateMap<Tag, TagResponse>().ReverseMap();
}
