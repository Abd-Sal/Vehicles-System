namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperModelExtensions
{
    //Model
    public static Model ToModel(this ModelRequest modelRequest, IMapper mapper)
        => mapper.Map<Model>(modelRequest);
    public static FullModelResponse ToFullModel(this Model model, IMapper mapper)
        => new FullModelResponse(model.Id, model.Make.ToMakeResponse(mapper), model.ModelName, model.ProductionYear);
    public static ModelResponse ToModelResponse(this Model model, IMapper mapper)
        => mapper.Map<ModelResponse>(model);
    public static List<ModelResponse> ToModelResponses(this IEnumerable<Model> models, IMapper mapper)
        => mapper.Map<List<ModelResponse>>(models);
    public static IQueryable<FullModelResponse> ToFullModellResponse(this IQueryable<Model> models, IMapper mapper)
        => models.AsNoTracking()
            .Include(x => x.Make)
            .Select(x => new FullModelResponse(x.Id, x.Make.ToMakeResponse(mapper), x.ModelName, x.ProductionYear));

}
