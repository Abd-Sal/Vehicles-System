namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsModelServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsModelServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<ModelResponse>> UpdateModel
        (string modelID, ModelRequest modelRequest, CancellationToken cancellationToken = default)
    {
        if (modelRequest is null)
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NullModel);

        if ((await appDbContext.Models.FindAsync(modelID, cancellationToken)) is not { } model)
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NotFoundModel);

        if (!(await appDbContext.Makes.AnyAsync(x => x.Id == modelRequest.MakeID, cancellationToken)))
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NotFoundMake);

        if (await appDbContext.Models.AnyAsync(x => x.Id != modelID &&
            (x.ModelName == modelRequest.ModelName && x.MakeID == modelRequest.MakeID && x.ProductionYear == modelRequest.ProductoinYear), cancellationToken))
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.DuplicatedModel);

        await appDbContext.Models.Where(x => x.Id == modelID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.ModelName, modelRequest.ModelName)
                    .SetProperty(x => x.ProductionYear, modelRequest.ProductoinYear)
                    .SetProperty(x => x.MakeID, modelRequest.MakeID),
                cancellationToken
            );

        return Result.Success(model.ToModelResponse(mapper));
    }

    public async Task<Result<FullModelResponse>> GetModelByID
        (string modelID, CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.Models
            .Include(x => x.Make)
            .SingleOrDefaultAsync(x => x.Id == modelID, cancellationToken))?
            .ToFullModel(mapper);

        if (result is null)
            return Result.Failure<FullModelResponse>(VehicleDetailsErrors.NotFoundModel);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FullModelResponse>>> GetModelsByMakeID
        (string makeID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Makes.AnyAsync(x => x.Id == makeID, cancellationToken)))
            return Result.Failure<PaginatedList<FullModelResponse>>(VehicleDetailsErrors.NotFoundMake);

        var query = appDbContext.Models
            .Where(x => x.MakeID == makeID)
            .ToFullModellResponse(mapper);

        var result = await PaginatedList<FullModelResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FullModelResponse>>> GetModelsByName
        (string modelName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Models
            .Where(x => x.ModelName.ToLower().Contains(modelName))
            .ToFullModellResponse(mapper);

        var result = await PaginatedList<FullModelResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<ModelResponse>>> GetAllModels
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Models.AsNoTracking()
            .ProjectTo<ModelResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<ModelResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }
    public async Task<Result<PaginatedList<FullModelResponse>>> GetAllFullModels
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Models.ToFullModellResponse(mapper);
        var result = await PaginatedList<FullModelResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);

    }

    public async Task<Result<ModelResponse>> AddModel
            (ModelRequest modelRequest, CancellationToken cancellationToken = default)
    {
        if (modelRequest is null)
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NullModel);

        if (await appDbContext.Models.AnyAsync(x => x.ModelName == modelRequest.ModelName.Trim() &&
            x.MakeID == modelRequest.MakeID && x.ProductionYear == modelRequest.ProductoinYear, cancellationToken))
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.DuplicatedModel);

        var model = modelRequest.ToModel(mapper);
        await appDbContext.Models.AddAsync(model, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(model.ToModelResponse(mapper));
    }

}

