namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsMakeServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsMakeServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<MakeResponse>> UpdateMake
        (string makeID, MakeRequest makeRequest, CancellationToken cancellationToken = default)
    {
        if (makeRequest is null)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NullMake);

        if ((await appDbContext.Makes.FindAsync(makeID, cancellationToken)) is not { } make)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NotFoundMake);

        if (await appDbContext.Makes.AnyAsync(x => x.Id != makeID && (x.MakeName == makeRequest.MakeName && x.CountryOfOrigin == makeRequest.CountryOfOrigin), cancellationToken))
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.DuplicatedMake);

        await appDbContext.Makes.Where(x => x.Id == makeID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.MakeName, makeRequest.MakeName)
                    .SetProperty(x => x.CountryOfOrigin, makeRequest.CountryOfOrigin),
                cancellationToken
            );

        return Result.Success(make.ToMakeResponse(mapper));
    }

    public async Task<Result<MakeResponse>> GetMakeByID
        (string makeID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.Makes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == makeID, cancellationToken)) is not { } make)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NotFoundMake);
        var result = make.ToMakeResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<MakeResponse>> GetMakeByName
        (string makeName, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.Makes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.MakeName == makeName, cancellationToken)) is not { } make)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NotFoundMake);
        var result = make.ToMakeResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<MakeResponse>>> SearchMakesByName
        (string makeName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Makes.AsNoTracking()
            .Where(x => x.MakeName.ToLower().Trim().Contains(makeName.ToLower().Trim()))
            .ProjectTo<MakeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<MakeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<MakeResponse>>> GetAllMakes
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Makes.AsNoTracking()
           .ProjectTo<MakeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<MakeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<MakeResponse>> AddMake
        (MakeRequest makeRequest, CancellationToken cancellationToken = default)
    {
        if (makeRequest is null)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NullMake);

        if (await appDbContext.Makes.AnyAsync(x => x.MakeName == makeRequest.MakeName.Trim() &&
            x.CountryOfOrigin == makeRequest.CountryOfOrigin, cancellationToken))
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.DuplicatedMake);

        var make = makeRequest.ToMake(mapper);
        await appDbContext.Makes.AddAsync(make, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(make.ToMakeResponse(mapper));
    }

}