namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsChargePortServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsChargePortServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<ChargePortResponse>> UpdateChargePort
        (string chargePortID, ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default)
    {
        if (chargePortRequest is null)
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.NullChargePort);

        if (await appDbContext.ChargePorts.FindAsync(chargePortID, cancellationToken) is not { } chargePort)
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.NotFoundChargePort);

        if (await appDbContext.ChargePorts.AnyAsync(x => x.Id != chargePortID &&
            x.PortName == chargePortRequest.PortName, cancellationToken))
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.DuplicatedChargePort);

        await appDbContext.ChargePorts.Where(x => x.Id == chargePortID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.PortName, chargePortRequest.PortName),
                cancellationToken
            );

        return Result.Success(chargePort.ToChargePortResponse(mapper));
    }

    public async Task<Result<ChargePortResponse>> AddChargePort
        (ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default)
    {
        if (chargePortRequest is null)
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.NullChargePort);

        if (await appDbContext.ChargePorts.AnyAsync(x => x.PortName == chargePortRequest.PortName.Trim(), cancellationToken))
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.DuplicatedChargePort);

        var chargePort = chargePortRequest.ToChargePort(mapper);
        await appDbContext.ChargePorts.AddAsync(chargePort, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(chargePort.ToChargePortResponse(mapper));
    }

    public async Task<Result<PaginatedList<ChargePortResponse>>> GetAllChargePorts
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.ChargePorts.AsNoTracking()
            .OrderBy(x => x.PortName)
            .ProjectTo<ChargePortResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<ChargePortResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<ChargePortResponse>> GetChargePortByID
        (string chargePortID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.ChargePorts.FindAsync(chargePortID, cancellationToken) is not { } chargePort)
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.NotFoundChargePort);
        return Result.Success(chargePort.ToChargePortResponse(mapper));
    }

    public async Task<Result<ChargePortResponse>> GetChargePortByName
        (string chargePortName, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.ChargePorts.SingleOrDefaultAsync(x => x.PortName == chargePortName.Trim(), cancellationToken) is not { } chargePort)
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.NotFoundChargePort);
        return Result.Success(chargePort.ToChargePortResponse(mapper));
    }

    public async Task<Result<PaginatedList<ChargePortResponse>>> SearchChargePortsByName
        (string chargePortName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.ChargePorts.AsNoTracking()
            .Where(x => x.PortName.ToLower().Contains(chargePortName.ToLower().Trim()))
            .OrderBy(x => x.PortName)
            .ProjectTo<ChargePortResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<ChargePortResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

}

