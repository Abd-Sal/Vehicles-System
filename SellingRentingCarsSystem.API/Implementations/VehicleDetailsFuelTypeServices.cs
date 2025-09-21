namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsFuelTypeServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsFuelTypeServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<FuelTypeResponse>> UpdateFuelType
        (string fuelTypeID, FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default)
    {
        if (fuelTypeRequest is null)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NullFuelType);

        if ((await appDbContext.FuelTypes.FindAsync(fuelTypeID, cancellationToken)) is not { } fuelType)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if (await appDbContext.FuelTypes.AnyAsync(x => x.Id != fuelTypeID && x.TypeName == fuelTypeRequest.FuelTypeName, cancellationToken))
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.DuplicatedFuelType);

        await appDbContext.FuelTypes.Where(x => x.Id == fuelTypeID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.TypeName, fuelTypeRequest.FuelTypeName),
                cancellationToken
            );

        return Result.Success(fuelType.ToFuelTypeResponse(mapper));
    }

    public async Task<Result<FuelTypeResponse>> GetFuelTypeByID
        (string fuelTypeID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.FuelTypes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == fuelTypeID, cancellationToken)) is not { } fuelType)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NotfoundFuelType);
        var result = fuelType.ToFuelTypeResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<FuelTypeResponse>> GetFuelTypeByName
        (string fuelTypeName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.FuelTypes.SingleOrDefaultAsync(x => x.TypeName.Trim().ToLower() == fuelTypeName.ToLower().Trim(), cancellationToken) is not { } fuelType)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NotfoundFuelType);
        return Result.Success(fuelType.ToFuelTypeResponse(mapper));
    }

    public async Task<Result<PaginatedList<FuelTypeResponse>>> SearchFuelTypesByName(
        string fuelTypeName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.FuelTypes.AsNoTracking()
            .Where(x => x.TypeName.ToLower().Contains(fuelTypeName.ToLower()))
            .ProjectTo<FuelTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FuelTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FuelTypeResponse>>> GetAllFuelTypes
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.FuelTypes.AsNoTracking()
            .OrderByDescending(x => x.TypeName)
           .ProjectTo<FuelTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FuelTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<FuelTypeResponse>> AddFuelType
        (FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default)
    {
        if (fuelTypeRequest is null)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NullFuelType);

        if (await appDbContext.FuelTypes.AnyAsync(x => x.TypeName == fuelTypeRequest.FuelTypeName.Trim(), cancellationToken))
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.DuplicatedFuelType);

        var fuelType = fuelTypeRequest.ToFuelType(mapper);
        await appDbContext.FuelTypes.AddAsync(fuelType, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(fuelType.ToFuelTypeResponse(mapper));
    }


}

