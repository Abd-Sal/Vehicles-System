namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsAspirationServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsAspirationServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<AspirationResponse>> UpdateAspirtaion
        (string aspirationID, AspirationRequest aspirationRequest, CancellationToken cancellationToken = default)
    {
        if (aspirationRequest is null)
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.NullAspiration);

        if ((await appDbContext.Aspirations.FindAsync(aspirationID, cancellationToken)) is not { } aspiration)
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.NotFoundAspiration);

        if (await appDbContext.Aspirations.AnyAsync(x => x.Id != aspirationID &&
            x.TypeName == aspirationRequest.TypeName, cancellationToken))
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.DuplicatedAspiration);

        await appDbContext.Aspirations.Where(x => x.Id == aspirationID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.TypeName, aspirationRequest.TypeName),
                cancellationToken
            );

        return Result.Success(aspiration.ToAspirationResponse(mapper));
    }

    public async Task<Result<PaginatedList<AspirationResponse>>> GetAllAspirations
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Aspirations.AsNoTracking()
            .OrderBy(x => x.TypeName)
            .ProjectTo<AspirationResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<AspirationResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<AspirationResponse>> GetAspirationByID
        (string aspirationID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Aspirations.FindAsync(aspirationID, cancellationToken) is not { } aspiration)
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.NotFoundAspiration);
        return Result.Success(aspiration.ToAspirationResponse(mapper));
    }

    public async Task<Result<AspirationResponse>> GetAspirationByName
        (string aspirationName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Aspirations.SingleOrDefaultAsync(x => x.TypeName == aspirationName.Trim(), cancellationToken) is not { } aspiration)
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.NotFoundAspiration);
        return Result.Success(aspiration.ToAspirationResponse(mapper));
    }

    public async Task<Result<PaginatedList<AspirationResponse>>> SearchAspirationsByName
        (string aspirationName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Aspirations.AsNoTracking()
            .Where(x => x.TypeName.ToLower().Contains(aspirationName.ToLower().Trim()))
            .OrderBy(x => x.TypeName)
            .ProjectTo<AspirationResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<AspirationResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<AspirationResponse>> AddAspiration
        (AspirationRequest aspirationRequest, CancellationToken cancellationToken = default)
    {
        if (aspirationRequest is null)
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.NullAspiration);

        if (await appDbContext.Aspirations.AnyAsync(x => x.TypeName == aspirationRequest.TypeName.Trim(), cancellationToken))
            return Result.Failure<AspirationResponse>(VehicleDetailsErrors.DuplicatedAspiration);

        var aspiration = aspirationRequest.ToAspiration(mapper);
        await appDbContext.Aspirations.AddAsync(aspiration, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(aspiration.ToAspirationResponse(mapper));
    }

}

