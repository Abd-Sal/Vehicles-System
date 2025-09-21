namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperFeaturesExtensions
{
    //Feature
    public static Feature ToFeature(this FeatureRequest featureRequest, IMapper mapper)
        => mapper.Map<Feature>(featureRequest);
    public static FeatureResponse ToFeatureResponse(this Feature feature, IMapper mapper)
        => mapper.Map<FeatureResponse>(feature);
    public static List<FeatureResponse> ToFeatureResponses(this IEnumerable<Feature> features, IMapper mapper)
        => mapper.Map<List<FeatureResponse>>(features);
}
