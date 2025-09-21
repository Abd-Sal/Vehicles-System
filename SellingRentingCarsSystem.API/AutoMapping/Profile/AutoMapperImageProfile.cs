namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperImageProfile : AutoMapper.Profile
{
    public AutoMapperImageProfile()
    {
        //Image
        ImageMapping();
        ImageResponseMapping();
    }
    //Image
    private void ImageMapping()
        => CreateMap<ImageRequest, Image>()
           .ForMember(dest => dest.SizeInBytes, opt => opt.MapFrom(src => src.Image.Length))
            .ReverseMap();
    private void ImageResponseMapping()
        => CreateMap<Image, ImageResponse>().ReverseMap();
}
