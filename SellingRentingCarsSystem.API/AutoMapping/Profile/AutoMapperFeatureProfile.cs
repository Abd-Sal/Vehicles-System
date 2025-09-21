namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperFeatureProfile : AutoMapper.Profile
{
    public AutoMapperFeatureProfile()
    {
        //Feature
        FeatureMapping();
        FeatureResponseMapping();
    }
    //Feature
    private void FeatureMapping()
        => CreateMap<FeatureRequest, Feature>().ReverseMap();
    private void FeatureResponseMapping()
        => CreateMap<Feature, FeatureResponse>().ReverseMap();
}
