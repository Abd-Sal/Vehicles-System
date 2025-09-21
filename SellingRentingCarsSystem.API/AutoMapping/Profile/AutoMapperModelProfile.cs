namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperModelProfile : AutoMapper.Profile
{
    public AutoMapperModelProfile()
    {
        //Model
        ModelMapping();
        ModelResponseMapping();
    }
    //Model
    private void ModelMapping()
        => CreateMap<ModelRequest, Model>().ReverseMap();
    private void ModelResponseMapping()
        => CreateMap<Model, ModelResponse>().ReverseMap();
}
