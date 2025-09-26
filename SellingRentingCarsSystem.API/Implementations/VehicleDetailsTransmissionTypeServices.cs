namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsTransmissionTypeServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsTransmissionTypeServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<TransmissionTypeResponse>> UpdateTransmissionType
        (string transmissionTypeID, TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default)
    {
        if (transmissionTypeRequest is null)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NullTransmissionType);

        if ((await appDbContext.TransmissionTypes.FindAsync([transmissionTypeID, cancellationToken], cancellationToken: cancellationToken)) is not { } transmissionType)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NotFoundTransmissionType);

        if (await appDbContext.TransmissionTypes.AnyAsync(x => x.Id != transmissionTypeID &&
            x.TypeName == transmissionTypeRequest.TypeName, cancellationToken))
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.DuplicatedTransmissionType);

        await appDbContext.TransmissionTypes.Where(x => x.Id == transmissionTypeID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.TypeName, transmissionTypeRequest.TypeName),
                cancellationToken
            );

        return Result.Success(transmissionType.ToTransmissionTypeResponse(mapper));
    }

    public async Task<Result<TransmissionTypeResponse>> GetTransmissionTypeByID
        (string transmissionTypeID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.TransmissionTypes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == transmissionTypeID, cancellationToken)) is not { } transmissionType)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NotFoundMake);
        var result = transmissionType.ToTransmissionTypeResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<TransmissionTypeResponse>>> SearchTransmissionTypesByName
        (string transmissionTypeName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.TransmissionTypes.AsNoTracking()
            .Where(x => x.TypeName.ToLower().Trim().Contains(transmissionTypeName.ToLower().Trim()))
            .ProjectTo<TransmissionTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<TransmissionTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<TransmissionTypeResponse>> GetTransmissionTypeByName
        (string transmissionTypeName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.TransmissionTypes.SingleOrDefaultAsync(x => x.TypeName.ToLower().Trim() == transmissionTypeName.ToLower().Trim(), cancellationToken) is not { } transmission)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NotFoundTransmissionType);
        return Result.Success(transmission.ToTransmissionTypeResponse(mapper));
    }
    
    public async Task<Result<PaginatedList<TransmissionTypeResponse>>> GetAllTransmissionTypes
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.TransmissionTypes.AsNoTracking()
            .ProjectTo<TransmissionTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<TransmissionTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<TransmissionTypeResponse>> AddTransmissionType
        (TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default)
    {
        if (transmissionTypeRequest is null)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NullTransmissionType);

        if (await appDbContext.TransmissionTypes.AnyAsync(x => x.TypeName.ToLower() == transmissionTypeRequest.TypeName.ToLower().Trim(), cancellationToken))
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.DuplicatedTransmissionType);

        var transmissionType = transmissionTypeRequest.ToTransmissionType(mapper);
        await appDbContext.TransmissionTypes.AddAsync(transmissionType, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(transmissionType.ToTransmissionTypeResponse(mapper));
    }

}

