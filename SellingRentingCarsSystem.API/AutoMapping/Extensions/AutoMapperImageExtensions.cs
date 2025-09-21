namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperImageExtensions
{
    //Image
    public static Image ToImage(this ImageRequest imageRequest, IMapper mapper)
        => mapper.Map<Image>(imageRequest);
    public static ImageResponse ToImageResponse(this Image image, IMapper mapper)
        => mapper.Map<ImageResponse>(image);
    public static List<ImageResponse> ToImageResponses(this IEnumerable<Image> images, IMapper mapper)
        => mapper.Map<List<ImageResponse>>(images);
}
