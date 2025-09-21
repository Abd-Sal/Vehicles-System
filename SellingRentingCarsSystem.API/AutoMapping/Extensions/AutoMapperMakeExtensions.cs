namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperMakeExtensions
{
    //Make
    public static Make ToMake(this MakeRequest makeRequest, IMapper mapper)
        => mapper.Map<Make>(makeRequest);
    public static MakeResponse ToMakeResponse(this Make make, IMapper mapper)
        => mapper.Map<MakeResponse>(make);
    public static List<MakeResponse> ToMakeResponses(this IEnumerable<Make> makes, IMapper mapper)
        => mapper.Map<List<MakeResponse>>(makes);
}
