namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsBodyTypeServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsBodyTypeServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<BodyTypeResponse>> UpdateBodyType
        (string bodyTypeID, BodyTypeRequest bodyTypeRequest, CancellationToken cancellationToken = default)
    {
        if (bodyTypeRequest is null)
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.NullBodyType);

        if ((await appDbContext.BodyTypes.FindAsync(bodyTypeID, cancellationToken)) is not { } bodyType)
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.NotFoundBodyType);

        if (await appDbContext.BodyTypes.AnyAsync(x => x.Id != bodyTypeID &&
            (x.TypeName == bodyTypeRequest.BodyTypeName && x.DoorCount == bodyTypeRequest.DoorCount), cancellationToken))
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.DuplicatedBodyType);

        await appDbContext.BodyTypes.Where(x => x.Id == bodyTypeID)
            .ExecuteUpdateAsync(setters =>
                setters
                .SetProperty(x => x.TypeName, bodyTypeRequest.BodyTypeName)
                .SetProperty(x => x.DoorCount, bodyTypeRequest.DoorCount),
                cancellationToken
            );

        return Result.Success(bodyType.ToBodyTypeResponse(mapper));
    }

    public async Task<Result<BodyTypeResponse>> AddBodyType
        (BodyTypeRequest bodyTypeRequest, CancellationToken cancellationToken = default)
    {
        if (bodyTypeRequest is null)
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.NullBodyType);

        if (await appDbContext.BodyTypes.AnyAsync(x => x.TypeName == bodyTypeRequest.BodyTypeName.Trim() &&
            x.DoorCount == bodyTypeRequest.DoorCount, cancellationToken))
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.DuplicatedBodyType);

        var bodyType = bodyTypeRequest.ToBodyType(mapper);
        await appDbContext.BodyTypes.AddAsync(bodyType, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(bodyType.ToBodyTypeResponse(mapper));
    }

    public async Task<Result<BodyTypeResponse>> GetBodyTypeByID
        (string bodyTypeID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.BodyTypes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == bodyTypeID, cancellationToken)) is not { } bodyType)
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.NotFoundBodyType);
        var result = bodyType.ToBodyTypeResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<BodyTypeResponse>> GetBodyTypeByName
        (string bodyTypeName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.BodyTypes.SingleOrDefaultAsync(x => x.TypeName.ToLower().Trim() == bodyTypeName.ToLower().Trim(), cancellationToken) is not { } bodyType)
            return Result.Failure<BodyTypeResponse>(VehicleDetailsErrors.NotFoundBodyType);
        return Result.Success(bodyType.ToBodyTypeResponse(mapper));
    }

    public async Task<Result<PaginatedList<BodyTypeResponse>>> SearchBodyTypesByName
        (string bodyTypeName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.BodyTypes.AsNoTracking()
            .Where(x => x.TypeName.ToLower().Contains(bodyTypeName.ToLower().Trim()))
            .ProjectTo<BodyTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<BodyTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<BodyTypeResponse>>> GetAllBodyTypes
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.BodyTypes.AsNoTracking()
            .OrderByDescending(x => x.TypeName)
            .ThenBy(x => x.DoorCount)
            .ProjectTo<BodyTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<BodyTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

}

