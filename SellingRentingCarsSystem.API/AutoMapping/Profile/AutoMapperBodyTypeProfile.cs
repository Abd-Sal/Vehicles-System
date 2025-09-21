namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperBodyTypeProfile : AutoMapper.Profile
{
    public AutoMapperBodyTypeProfile()
    {
        //BodyType
        BodyTypeMapping();
        BodyTypeMappingResponse();

    }
    //BodyType
    private void BodyTypeMapping()
        => CreateMap<BodyTypeRequest, BodyType>()
        .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.BodyTypeName))
        .ReverseMap()
        .ForMember(dest => dest.BodyTypeName, opt => opt.MapFrom(src => src.TypeName));
    private void BodyTypeMappingResponse()
        => CreateMap<BodyType, BodyTypeResponse>().ReverseMap();
}
