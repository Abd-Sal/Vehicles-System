namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperTagExtensions
{
    //Tag
    public static List<TagResponse> ToTagResponses(this IEnumerable<Tag> tags, IMapper mapper)
        => mapper.Map<List<TagResponse>>(tags);
}
