namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperBodyTypeExtensions
{
    //BodyType
    public static BodyType ToBodyType(this BodyTypeRequest bodyTypeRequest, IMapper mapper)
        => mapper.Map<BodyType>(bodyTypeRequest);
    public static BodyTypeResponse ToBodyTypeResponse(this BodyType bodyType, IMapper mapper)
        => mapper.Map<BodyTypeResponse>(bodyType);
    public static List<BodyTypeResponse> ToBodyTypeResponses(this IEnumerable<BodyType> bodyTypes, IMapper mapper)
        => mapper.Map<List<BodyTypeResponse>>(bodyTypes);

}
