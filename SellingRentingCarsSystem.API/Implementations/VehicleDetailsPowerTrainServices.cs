namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsPowerTrainServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsPowerTrainServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    public async Task<Result<PowerTrainResponse>> UpdateCombinationPowerTrain
        (string powerTrainID, UpdateCombinationPowerTrainRequest updateCombinationPowerTrainRequest, CancellationToken cancellationToken = default)
    {
        if (updateCombinationPowerTrainRequest is null)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NullPowerTrain);

        if (!(await appDbContext.FuelTypes.AnyAsync(x => x.Id == updateCombinationPowerTrainRequest.FuelTypeID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if (!(await appDbContext.Aspirations.AnyAsync(x => x.Id == updateCombinationPowerTrainRequest.AspirationID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundAspiration);

        if (!(await appDbContext.FuelDeliveries.AnyAsync(x => x.Id == updateCombinationPowerTrainRequest.FuelDeliveryID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);

        if ((await appDbContext.PowerTrains.FindAsync(powerTrainID, cancellationToken)) is not { } powerTrain)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundPowerTrain);

        var hashcode = updateCombinationPowerTrainRequest.HashCode();
        if (await appDbContext.PowerTrains.AnyAsync(x => x.Id != powerTrainID && x.HashCode == hashcode, cancellationToken))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.DuplicatedPowerTrain);

        await appDbContext.PowerTrains.Where(x => x.Id == powerTrainID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.Cylinders, updateCombinationPowerTrainRequest.Cylinders)
                    .SetProperty(x => x.Torque, updateCombinationPowerTrainRequest.Torque)
                    .SetProperty(x => x.HorsePower, updateCombinationPowerTrainRequest.HorsePower)
                    .SetProperty(x => x.FuelDeliveryID, updateCombinationPowerTrainRequest.FuelDeliveryID)
                    .SetProperty(x => x.FuelTypeID, updateCombinationPowerTrainRequest.FuelTypeID)
                    .SetProperty(x => x.CombinedRangeMiles, updateCombinationPowerTrainRequest.CombinedRangeMiles)
                    .SetProperty(x => x.AspirationID, updateCombinationPowerTrainRequest.AspirationID)
                    .SetProperty(x => x.EngineSize, updateCombinationPowerTrainRequest.EngineSize)
                    .SetProperty(x => x.HashCode, hashcode),
                cancellationToken
            );

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<PowerTrainResponse>> UpdateElectricPowerTrain
        (string powerTrainID, UpdateElectricPowerTrainRequest updateElectricPowerTrainRequest, CancellationToken cancellationToken = default)
    {
        if (updateElectricPowerTrainRequest is null)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NullPowerTrain);

        if (!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == updateElectricPowerTrainRequest.ChargePortID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundChargePort);

        if ((await appDbContext.PowerTrains.FindAsync(powerTrainID, cancellationToken)) is not { } powerTrain)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundPowerTrain);

        var hashcode = updateElectricPowerTrainRequest.HashCode();
        if (await appDbContext.PowerTrains.AnyAsync(x => x.Id != powerTrainID && x.HashCode == hashcode, cancellationToken))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.DuplicatedPowerTrain);

        await appDbContext.PowerTrains.Where(x => x.Id == powerTrainID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.BatteryCapacityKWh, updateElectricPowerTrainRequest.BatteryCapacityKWh)
                    .SetProperty(x => x.Torque, updateElectricPowerTrainRequest.Torque)
                    .SetProperty(x => x.HorsePower, updateElectricPowerTrainRequest.HorsePower)
                    .SetProperty(x => x.ElectricOnlyRangeMiles, updateElectricPowerTrainRequest.ElectricOnlyRangeMiles)
                    .SetProperty(x => x.ChargePortID, updateElectricPowerTrainRequest.ChargePortID)
                    .SetProperty(x => x.HashCode, hashcode),
                cancellationToken
            );

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<PowerTrainResponse>> UpdateHybridPowerTrain
        (string powerTrainID, UpdateHybridPowerTrainRequest updateHybridPowerTrainRequest, CancellationToken cancellationToken = default)
    {
        if (updateHybridPowerTrainRequest is null)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NullPowerTrain);

        if (!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == updateHybridPowerTrainRequest.ChargePortID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundChargePort);

        if (!(await appDbContext.FuelTypes.AnyAsync(x => x.Id == updateHybridPowerTrainRequest.FuelTypeID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if (!(await appDbContext.FuelDeliveries.AnyAsync(x => x.Id == updateHybridPowerTrainRequest.FuelDeliveryID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);

        if (!(await appDbContext.Aspirations.AnyAsync(x => x.Id == updateHybridPowerTrainRequest.AspirationID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundAspiration);

        if ((await appDbContext.PowerTrains.FindAsync(powerTrainID, cancellationToken)) is not { } powerTrain)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundPowerTrain);

        var hashcode = updateHybridPowerTrainRequest.HashCode();
        if (await appDbContext.PowerTrains.AnyAsync(x => x.Id != powerTrainID && x.HashCode == hashcode, cancellationToken))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.DuplicatedPowerTrain);

        var hybridType = updateHybridPowerTrainRequest.PlugInHybrid
            ? PowerTrainTypes.plugInHybrid.ToString()
            : PowerTrainTypes.hybrid.ToString();
        await appDbContext.PowerTrains.Where(x => x.Id == powerTrainID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.EngineSize, updateHybridPowerTrainRequest.EngineSize)
                    .SetProperty(x => x.CombinedRangeMiles, updateHybridPowerTrainRequest.CombinationRangeMiles)
                    .SetProperty(x => x.AspirationID, updateHybridPowerTrainRequest.AspirationID)
                    .SetProperty(x => x.Cylinders, updateHybridPowerTrainRequest.Cylinders)
                    .SetProperty(x => x.FuelDeliveryID, updateHybridPowerTrainRequest.FuelDeliveryID)
                    .SetProperty(x => x.FuelTypeID, updateHybridPowerTrainRequest.FuelTypeID)
                    .SetProperty(x => x.BatteryCapacityKWh, updateHybridPowerTrainRequest.BatteryCapacityKWh)
                    .SetProperty(x => x.Torque, updateHybridPowerTrainRequest.Torque)
                    .SetProperty(x => x.HorsePower, updateHybridPowerTrainRequest.HorsePower)
                    .SetProperty(x => x.ElectricOnlyRangeMiles, updateHybridPowerTrainRequest.ElectricOnlyRangeMiles)
                    .SetProperty(x => x.ChargePortID, updateHybridPowerTrainRequest.ChargePortID)
                    .SetProperty(x => x.PowerTrainType, hybridType)
                    .SetProperty(x => x.HashCode, hashcode),
                cancellationToken
            );

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<PowerTrainResponse>> AddCombinationPowerTrain
        (CombinationPowerTrainRequest combinationPowerTrainRequest, CancellationToken cancellationToken = default)
    {
        if (combinationPowerTrainRequest is null)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NullPowerTrain);

        if (!(await appDbContext.FuelTypes.AnyAsync(x => x.Id == combinationPowerTrainRequest.FuelTypeID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if (!(await appDbContext.FuelDeliveries.AnyAsync(x => x.Id == combinationPowerTrainRequest.FuelDeliveryID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);

        if (!(await appDbContext.Aspirations.AnyAsync(x => x.Id == combinationPowerTrainRequest.AspirationID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundAspiration);

        var powerTrain = combinationPowerTrainRequest.ToPowerTrain(mapper);
        powerTrain.PowerTrainType = PowerTrainTypes.ice.ToString();
        powerTrain.HashCode = combinationPowerTrainRequest.HashCode();
        if (await appDbContext.PowerTrains.AnyAsync(x => x.HashCode == powerTrain.HashCode, cancellationToken))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.DuplicatedPowerTrain);

        await appDbContext.PowerTrains.AddAsync(powerTrain, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<PowerTrainResponse>> AddElectricPowerTrain
        (ElectricPowerTrainRequest electricPowerTrainRequest, CancellationToken cancellationToken = default)
    {
        if (electricPowerTrainRequest is null)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NullPowerTrain);

        if (!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == electricPowerTrainRequest.ChargePortID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundChargePort);

        var powerTrain = electricPowerTrainRequest.ToPowerTrain(mapper);
        powerTrain.PowerTrainType = PowerTrainTypes.electric.ToString();
        powerTrain.HashCode = electricPowerTrainRequest.HashCode();
        if (await appDbContext.PowerTrains.AnyAsync(x => x.HashCode == powerTrain.HashCode, cancellationToken))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.DuplicatedPowerTrain);

        await appDbContext.PowerTrains.AddAsync(powerTrain, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<PowerTrainResponse>> AddHybridPowerTrain
        (HybridPowerTrainRequest hybridPowerTrainRequest, CancellationToken cancellationToken = default)
    {
        if (hybridPowerTrainRequest is null)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NullPowerTrain);

        if (!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == hybridPowerTrainRequest.ChargePortID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundChargePort);

        if (!(await appDbContext.FuelDeliveries.AnyAsync(x => x.Id == hybridPowerTrainRequest.FuelDeliveryID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundFuelDelivery);

        if (!(await appDbContext.FuelTypes.AnyAsync(x => x.Id == hybridPowerTrainRequest.FuelTypeID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if (!(await appDbContext.Aspirations.AnyAsync(x => x.Id == hybridPowerTrainRequest.AspirationID, cancellationToken)))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundAspiration);

        var powerTrain = hybridPowerTrainRequest.ToPowerTrain(mapper);
        powerTrain.PowerTrainType = hybridPowerTrainRequest.PlugInHybrid
            ? PowerTrainTypes.plugInHybrid.ToString()
            : PowerTrainTypes.hybrid.ToString();
        powerTrain.HashCode = hybridPowerTrainRequest.HashCode();
        if (await appDbContext.PowerTrains.AnyAsync(x => x.HashCode == powerTrain.HashCode, cancellationToken))
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.DuplicatedPowerTrain);

        await appDbContext.PowerTrains.AddAsync(powerTrain, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<FullPowerTrainResponse>> GetPowerTrainByID
        (string powerTrainID, CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.PowerTrains
            .Include(x => x.ChargePort)
            .Include(x => x.FuleType)
            .Include(x => x.FuelDelivery)
            .Include(x => x.Aspiration)
            .SingleOrDefaultAsync(x => x.Id == powerTrainID, cancellationToken))?
            .ToFullPowerTrain(mapper);

        if (result is null)
            return Result.Failure<FullPowerTrainResponse>(VehicleDetailsErrors.NotFoundModel);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FullPowerTrainResponse>>> GetPowerTrainsByName
        (string powerTrainName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.PowerTrains
            .Where(x => x.PowerTrainType == powerTrainName)
            .ToFullPowerTrain(mapper);

        var result = await PaginatedList<FullPowerTrainResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<PowerTrainResponse>>> GetAllPowerTrains
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.PowerTrains.AsNoTracking()
            .ProjectTo<PowerTrainResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<PowerTrainResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<FullPowerTrainResponse>>> GetAllFullPowerTrains
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.PowerTrains
            .ToFullPowerTrain(mapper);

        var result = await PaginatedList<FullPowerTrainResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

}

