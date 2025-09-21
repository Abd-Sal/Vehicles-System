namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsFeatureServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsFeatureServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<FeatureResponse>> UpdateFeature
        (string featureID, FeatureRequest featureRequest, CancellationToken cancellationToken = default)
    {
        if (featureRequest is null)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NullFeature);

        if ((await appDbContext.Features.FindAsync(featureID, cancellationToken)) is not { } feature)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NotfoundFeature);

        if (await appDbContext.Features.AnyAsync(x => x.Id != featureID && (x.FeatureName == featureRequest.FeatureName && x.Category == featureRequest.Category), cancellationToken))
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NotfoundFeature);

        await appDbContext.Features.Where(x => x.Id == featureID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.FeatureName, featureRequest.FeatureName)
                    .SetProperty(x => x.Category, featureRequest.Category),
                cancellationToken
            );

        return Result.Success(feature.ToFeatureResponse(mapper));
    }

    public async Task<Result<FeatureResponse>> GetFeatureByID
        (string featureID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.Features.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == featureID, cancellationToken)) is not { } feature)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NotfoundFeature);
        var result = feature.ToFeatureResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FeatureResponse>>> SearchFeaturesByName
        (string featureName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Features.AsNoTracking()
            .Where(x => x.FeatureName.ToLower().Trim().Contains(featureName.ToLower().Trim()))
            .ProjectTo<FeatureResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FeatureResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<FeatureResponse>> GetFeatureByName
        (string featureName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Features.FirstOrDefaultAsync(x => x.FeatureName.ToLower().Trim() == featureName.ToLower().Trim(), cancellationToken) is not { } feature)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NotfoundFeature);
        return Result.Success(feature.ToFeatureResponse(mapper));
    }

    public async Task<Result<PaginatedList<FeatureResponse>>> GetAllFeatures
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Features.AsNoTracking()
           .ProjectTo<FeatureResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FeatureResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<FeatureResponse>> AddFeature
        (FeatureRequest featureRequest, CancellationToken cancellationToken = default)
    {
        if (featureRequest is null)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NullFeature);

        if (await appDbContext.Features.AnyAsync(x => x.FeatureName == featureRequest.FeatureName.Trim(), cancellationToken))
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.DuplicatedFeature);

        var feature = featureRequest.ToFeature(mapper);
        await appDbContext.Features.AddAsync(feature, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(feature.ToFeatureResponse(mapper));
    }

}

