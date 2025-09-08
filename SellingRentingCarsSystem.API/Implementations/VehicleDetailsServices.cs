namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleDetailsServices(AppDbContext appDbContext, IMapper mapper) : IVehicleDetailsServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;

    //Add
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

        if(!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == electricPowerTrainRequest.ChargePortTypeID, cancellationToken)))
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

    public async Task<Result<TransmissionTypeResponse>> AddTransmissionType
        (TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default)
    {
        if (transmissionTypeRequest is null)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NullTransmissionType);

        if (await appDbContext.TransmissionTypes.AnyAsync(x => x.TypeName == transmissionTypeRequest.TransmissionTypeName.Trim(), cancellationToken))
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.DuplicatedTransmissionType);

        var transmissionType = transmissionTypeRequest.ToTransmissionType(mapper);
        await appDbContext.TransmissionTypes.AddAsync(transmissionType, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(transmissionType.ToTransmissionTypeResponse(mapper));
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

    public async Task<Result<ChargePortResponse>> AddChargePort
        (ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default)
    {
        if (chargePortRequest is null)
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.NullChargePort);

        if (await appDbContext.ChargePorts.AnyAsync(x => x.PortName== chargePortRequest.PortName.Trim(), cancellationToken))
            return Result.Failure<ChargePortResponse>(VehicleDetailsErrors.DuplicatedChargePort);

        var chargePort = chargePortRequest.ToChargePort(mapper);
        await appDbContext.ChargePorts.AddAsync(chargePort, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(chargePort.ToChargePortResponse(mapper));
    }


    //Get
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

    public async Task<Result<PaginatedList<FeatureResponse>>> GetAllFeatures
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Features.AsNoTracking()
           .ProjectTo<FeatureResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<FeatureResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

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

    public async Task<Result<PaginatedList<MakeResponse>>> GetAllMakes
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Makes.AsNoTracking()
           .ProjectTo<MakeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<MakeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

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

    public async Task<Result<PaginatedList<PowerTrainResponse>>> GetAllPowerTrains
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.PowerTrains.AsNoTracking()
            .ProjectTo<PowerTrainResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<PowerTrainResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<TransmissionTypeResponse>>> GetAllTransmissionTypes
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.TransmissionTypes.AsNoTracking()
            .ProjectTo<TransmissionTypeResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<TransmissionTypeResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
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

    public async Task<Result<ModelResponse>> GetModelByID
        (string modelID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.Models.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == modelID, cancellationToken)) is not { } model)
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NotFoundMake);
        var result = model.ToModelResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<ModelResponse>>> GetModelsByMakeID
        (string makeID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Models.AsNoTracking()
            .Where(x => x.MakeID == makeID)
            .ProjectTo<ModelResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<ModelResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<ModelResponse>>> GetModelsByName
        (string modelName, RequestFilters filters, CancellationToken cancellationToken = default)
    {

        var query = appDbContext.Models.AsNoTracking()
            .OrderByDescending(x => x.ModelName)
            .ThenByDescending(x => x.ProductionYear)
            .ProjectTo<ModelResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<ModelResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PowerTrainResponse>> GetPowerTrainByID
        (string powerTrainID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.PowerTrains.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == powerTrainID, cancellationToken)) is not { } powerTrain)
            return Result.Failure<PowerTrainResponse>(VehicleDetailsErrors.NotFoundMake);
        var result = powerTrain.ToPowerTrainResponse(mapper);
        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<PowerTrainResponse>>> GetPowerTrainsByName
        (string powerTrainName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.PowerTrains.AsNoTracking()
            .Where(x => x.PowerTrainType == powerTrainName)
            .ProjectTo<PowerTrainResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<PowerTrainResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
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


    //Update
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

        if (!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == updateElectricPowerTrainRequest.ChargePortTypeID, cancellationToken)))
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
                    .SetProperty(x => x.ElectricOnlyRangeMiles, updateElectricPowerTrainRequest.ElectricRangeMiles)
                    .SetProperty(x => x.ChargePortID, updateElectricPowerTrainRequest.ChargePortTypeID)
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

        if (!(await appDbContext.ChargePorts.AnyAsync(x => x.Id == updateHybridPowerTrainRequest.ChargePortTypeID, cancellationToken)))
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
                    .SetProperty(x => x.ElectricOnlyRangeMiles, updateHybridPowerTrainRequest.ElectricRangeMiles)
                    .SetProperty(x => x.ChargePortID, updateHybridPowerTrainRequest.ChargePortTypeID)
                    .SetProperty(x => x.PowerTrainType, hybridType)
                    .SetProperty(x => x.HashCode, hashcode),
                cancellationToken
            );

        return Result.Success(powerTrain.ToPowerTrainResponse(mapper));
    }

    public async Task<Result<FeatureResponse>> UpdateFeature
        (string featureID, FeatureRequest featureRequest, CancellationToken cancellationToken = default)
    {
        if (featureRequest is null)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NullFeature);

        if ((await appDbContext.Features.FindAsync(featureID, cancellationToken)) is not { } feature)
            return Result.Failure<FeatureResponse>(VehicleDetailsErrors.NotfoundFeature);

        if(await appDbContext.Features.AnyAsync(x => x.Id != featureID && (x.FeatureName == featureRequest.FeatureName && x.Category == featureRequest.Category), cancellationToken))
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

    public async Task<Result<FuelTypeResponse>> UpdateFuelType
        (string fuelTypeID, FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default)
    {
        if(fuelTypeRequest is null)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NullFuelType);

        if((await appDbContext.FuelTypes.FindAsync(fuelTypeID, cancellationToken)) is not { } fuelType)
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if(await appDbContext.FuelTypes.AnyAsync(x => x.Id != fuelTypeID && x.TypeName == fuelTypeRequest.FuelTypeName, cancellationToken))
            return Result.Failure<FuelTypeResponse>(VehicleDetailsErrors.DuplicatedFuelType);

        await appDbContext.FuelTypes.Where(x => x.Id == fuelTypeID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.TypeName, fuelTypeRequest.FuelTypeName),
                cancellationToken
            );

        return Result.Success(fuelType.ToFuelTypeResponse(mapper));
    }

    public async Task<Result<MakeResponse>> UpdateMake
        (string makeID, MakeRequest makeRequest, CancellationToken cancellationToken = default)
    {
        if(makeRequest is null)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NullMake);

        if((await appDbContext.Makes.FindAsync(makeID, cancellationToken)) is not { } make)
            return Result.Failure<MakeResponse>(VehicleDetailsErrors.NotFoundMake);

        if(await appDbContext.Makes.AnyAsync(x => x.Id != makeID && (x.MakeName == makeRequest.MakeName && x.CountryOfOrigin == makeRequest.CountryOfOrigin), cancellationToken))
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

    public async Task<Result<ModelResponse>> UpdateModel
        (string modelID, ModelRequest modelRequest, CancellationToken cancellationToken = default)
    {
        if (modelRequest is null)
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NullModel);

        if ((await appDbContext.Models.FindAsync(modelID, cancellationToken)) is not { } model)
            return Result.Failure<ModelResponse>(VehicleDetailsErrors.NotFoundModel);

        if(!(await appDbContext.Makes.AnyAsync(x => x.Id == modelRequest.MakeID, cancellationToken)))
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

    public async Task<Result<TransmissionTypeResponse>> UpdateTransmissionType
        (string transmissionTypeID, TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default)
    {
        if (transmissionTypeRequest is null)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NullTransmissionType);

        if ((await appDbContext.TransmissionTypes.FindAsync(transmissionTypeID, cancellationToken)) is not { } transmissionType)
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.NotFoundTransmissionType);

        if (await appDbContext.TransmissionTypes.AnyAsync(x => x.Id != transmissionTypeID &&
            x.TypeName == transmissionTypeRequest.TransmissionTypeName, cancellationToken))
            return Result.Failure<TransmissionTypeResponse>(VehicleDetailsErrors.DuplicatedTransmissionType);

        await appDbContext.TransmissionTypes.Where(x => x.Id == transmissionTypeID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.TypeName, transmissionTypeRequest.TransmissionTypeName),
                cancellationToken
            );

        return Result.Success(transmissionType.ToTransmissionTypeResponse(mapper));
    }

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

}
