namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsFuelDeliveryServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsFuelDeliveryServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<FuelDeliveryResponse>> UpdateFuelDelivery
        (string fuelDeliveryID, FuelDeliveryRequest fuelDeliveryRequest, CancellationToken cancellationToken = default)
    {
        if (fuelDeliveryRequest is null)
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.NullTransmissionType);

        if ((await appDbContext.FuelDeliveries.FindAsync(fuelDeliveryID, cancellationToken)) is not { } fuelDelivery)
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);

        if (await appDbContext.FuelDeliveries.AnyAsync(x => x.Id != fuelDeliveryID &&
            x.TypeName == fuelDeliveryRequest.TypeName, cancellationToken))
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.DuplicatedFuelDelivery);

        await appDbContext.FuelDeliveries.Where(x => x.Id == fuelDeliveryID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.TypeName, fuelDeliveryRequest.TypeName),
                cancellationToken
            );

        return Result.Success(fuelDelivery.ToFuelDeliveryResponse(mapper));

    }

    public async Task<Result<PaginatedList<FuelDeliveryResponse>>> GetAllFuelDeliveries
    (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.FuelDeliveries.AsNoTracking()
            .OrderBy(x => x.TypeName)
            .ProjectTo<FuelDeliveryResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FuelDeliveryResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<FuelDeliveryResponse>> GetFuelDeliveryByID
        (string fuelDeliveryID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.FuelDeliveries.FindAsync(fuelDeliveryID, cancellationToken) is not { } fuelDelivery)
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);
        return Result.Success(fuelDelivery.ToFuelDeliveryResponse(mapper));
    }

    public async Task<Result<FuelDeliveryResponse>> GetFuelDeliveryByName
        (string fuelDeliveryName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.FuelDeliveries.SingleOrDefaultAsync(x => x.TypeName == fuelDeliveryName.Trim(), cancellationToken) is not { } fuelDelivery)
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);
        return Result.Success(fuelDelivery.ToFuelDeliveryResponse(mapper));
    }

    public async Task<Result<PaginatedList<FuelDeliveryResponse>>> SearchFuelDeliveriesByName
        (string fuelDeliveryName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.FuelDeliveries.AsNoTracking()
            .Where(x => x.TypeName.ToLower().Contains(fuelDeliveryName.ToLower().Trim()))
            .OrderBy(x => x.TypeName)
            .ProjectTo<FuelDeliveryResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FuelDeliveryResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<FuelDeliveryResponse>> AddFuelDelivery
        (FuelDeliveryRequest fuelDeliveryRequest, CancellationToken cancellationToken = default)
    {
        if (fuelDeliveryRequest is null)
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.NullFuelDelivery);

        if (await appDbContext.FuelDeliveries.AnyAsync(x => x.TypeName == fuelDeliveryRequest.TypeName.Trim(), cancellationToken))
            return Result.Failure<FuelDeliveryResponse>(VehicleDetailsErrors.DuplicatedFuelDelivery);

        var fuelDelivery = fuelDeliveryRequest.ToFuelDelivery(mapper);
        await appDbContext.FuelDeliveries.AddAsync(fuelDelivery, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(fuelDelivery.ToFuelDeliveryResponse(mapper));
    }


}

