namespace SellingRentingCarsSystem.API.Implementations;

public class VehicleServices(
        AppDbContext appDbContext, IMapper mapper,
        IVehicleDetailsServices vehicleDetailsServices,
        IPaymentServices paymentServices, IOptionsMonitor<ImagesProperties> imageOptions,
        IWebHostEnvironment webHostEnvironment
    ) : IVehicleServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly IVehicleDetailsServices vehicleDetailsServices = vehicleDetailsServices;
    private readonly IPaymentServices paymentServices = paymentServices;
    private readonly IWebHostEnvironment webHostEnvironment = webHostEnvironment;
    private readonly ImagesProperties imageOptions = imageOptions.CurrentValue;

    public async Task<Result<VehicleFeatureResponse>> AddFeatureForVehicle
        (string vehicleID, VehicleFeatureRequest vehicleFeatureRequest, CancellationToken cancellationToken = default)
    {
        if (vehicleFeatureRequest is null)
            return Result.Failure<VehicleFeatureResponse>(VehicleErrors.NullVehicleFeature);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<VehicleFeatureResponse>(VehicleErrors.NotFoundVehicle);

        if (!(await appDbContext.Features.AnyAsync(x => x.Id == vehicleFeatureRequest.FeatureID, cancellationToken)))
            return Result.Failure<VehicleFeatureResponse>(VehicleDetailsErrors.NotfoundFeature);

        if (await appDbContext.VehicleFeatures.AnyAsync(x => x.VehicleID == vehicleID && x.FeatureID == vehicleFeatureRequest.FeatureID, cancellationToken))
            return Result.Failure<VehicleFeatureResponse>(VehicleErrors.DuplicatedVehicleFeature);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<VehicleFeatureResponse>(VehicleErrors.UnavailableVehicle);

        var vehicleFeature = vehicleFeatureRequest.ToVehicleFeature(mapper);
        var add = await appDbContext.VehicleFeatures.AddAsync(vehicleFeature, cancellationToken);
        var result = await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(vehicleFeature.ToVehicleFeatureResponse(mapper));
    }

    public async Task<Result<BriefVehicleResponse>> AddFullVehicle      //TODO : enhance the code in private method and in this method
        (IVehicleRequest vehicleRequest, CancellationToken cancellationToken = default)
    {
        if(vehicleRequest is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);

        Result<BriefVehicleResponse>? result = null;
        using (var trans = appDbContext.Database.BeginTransactionAsync())
        {
            var fullCombination = vehicleRequest as FullCombinationVehicleRequest;
            if (fullCombination is not null)
                result = await AddFullCombinationVehicle(fullCombination, cancellationToken);

            var fullElectric = vehicleRequest as FullElectricVehicleRequest;
            if (fullElectric is not null)
                result = await AddFullElectricVehicle(fullElectric, cancellationToken);

            var fullHybrid = vehicleRequest as FullHybridVehicleRequest;
            if (fullHybrid is not null)
                result = await AddFullHybridVehicle(fullHybrid, cancellationToken);
        }
        if(result is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);
        return result;
    }

    public async Task<Result<BriefVehicleResponse>> AddVehicle
        (VehicleRequest vehicleRequest, CancellationToken cancellationToken = default)
    {
        if (vehicleRequest is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.VIN == vehicleRequest.VIN, cancellationToken))
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.DuplicatedVehicleVIN);

        if (!(await appDbContext.Models.AnyAsync(x => x.Id == vehicleRequest.ModelID, cancellationToken)))
            return Result.Failure<BriefVehicleResponse>(VehicleDetailsErrors.NotFoundModel);

        if (!(await appDbContext.BodyTypes.AnyAsync(x => x.Id == vehicleRequest.BodyTypeID, cancellationToken)))
            return Result.Failure<BriefVehicleResponse>(VehicleDetailsErrors.NotFoundBodyType);

        if (vehicleRequest.FuelTypeID is not null &&
            !(await appDbContext.FuelTypes.AnyAsync(x => x.Id == vehicleRequest.FuelTypeID, cancellationToken)))
            return Result.Failure<BriefVehicleResponse>(VehicleDetailsErrors.NotfoundFuelType);

        if(await appDbContext.TransmissionTypes.AnyAsync(x => x.Id == vehicleRequest.TransmissionTypeID, cancellationToken))
            return Result.Failure<BriefVehicleResponse>(VehicleDetailsErrors.NotFoundTransmissionType);

        if(await appDbContext.PowerTrains.AnyAsync(x => x.Id == vehicleRequest.PowerTrainID, cancellationToken))
            return Result.Failure<BriefVehicleResponse>(VehicleDetailsErrors.NotFoundPowerTrain);

        var vehicle = vehicleRequest.ToVehicle(mapper);
        var add = await appDbContext.Vehicles.AddAsync(vehicle, cancellationToken);
        var result = await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(vehicle.ToBriefVehicleResponse(mapper));
    }

    public async Task<Result<PaginatedList<VehicleResponse>>> GetAllVehicles
        (bool availableOnly, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Vehicles
            .Where(x => availableOnly ? x.VehicleStatus == VehiclesStatus.available.ToString() : true)
            .ToVehicleResponse(mapper)
            .OrderByDescending(x => x.AddDate);

        var result = await PaginatedList<VehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<VehicleResponse>>> GetVehiclesByPowerTrainType   //TODO : check the code
        (VehiclePowerTrainRequest vehiclePowerTrainRequest, bool availableOnly, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var test = Enum.GetNames<PowerTrainTypes>();
        if (test.SingleOrDefault(x => x == vehiclePowerTrainRequest.PowerTrain) is not { } powerTrainType)
            return Result.Failure<PaginatedList<VehicleResponse>>(VehicleDetailsErrors.WrongePowerTrain);

        var query = appDbContext.Vehicles
            .Include(x => x.PowerTrain)
            .Where(x => x.PowerTrain.PowerTrainType == powerTrainType &&
                availableOnly ? x.VehicleStatus == VehiclesStatus.available.ToString() : true)
            .ToVehicleResponse(mapper)
            .OrderByDescending(x => x.AddDate);

        var result = await PaginatedList<VehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<VehicleResponse>>> GetVehiclesByPowerTrainID   //TODO : check the code
        (string powerTrainID, bool availableOnly, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.PowerTrains.AnyAsync(x => x.Id == powerTrainID, cancellationToken)))
            return Result.Failure<PaginatedList<VehicleResponse>>(VehicleDetailsErrors.NotFoundPowerTrain);

        var query = appDbContext.Vehicles
            .Where(x => x.PowerTrainID == powerTrainID &&
                availableOnly ? x.VehicleStatus == VehiclesStatus.available.ToString() : true)
            .ToVehicleResponse(mapper)
            .OrderByDescending(x => x.AddDate);

        var result = await PaginatedList<VehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<VehicleResponse>> GetVehicle
        (string vehicleID, bool availavle = true, CancellationToken cancellationToken = default)
    {
        var vehicleResponse = (await appDbContext.Vehicles
            .Include(x => x.BodyType)
            .Include(x => x.Model)
            .Include(x => x.Model.Make)
            .Include(x => x.TransmissionType)
            .Include(x => x.PowerTrain)
            .Include(x => x.PowerTrain.ChargePort)
            .Include(x => x.PowerTrain.FuleType)
            .Include(x => x.PowerTrain.FuelDelivery)
            .Include(x => x.PowerTrain.Aspiration)
            .SingleOrDefaultAsync(x => x.Id == vehicleID, cancellationToken))?
            .ToFullVehicleResponse(mapper);

        if(vehicleResponse is null)
            return Result.Failure<VehicleResponse>(VehicleErrors.NotFoundVehicle);
        if(availavle && vehicleResponse.VehicleStatus != VehiclesStatus.available.ToString())
            return Result.Failure<VehicleResponse>(VehicleErrors.UnavailableVehicle);

        return Result.Success(vehicleResponse);
    }

    public async Task<Result<List<FeatureResponse>>> GetFeaturesForVehicle
        (string vehicleID, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<List<FeatureResponse>>(VehicleErrors.NotFoundVehicle);

        var result = (await appDbContext.VehicleFeatures.AsNoTracking()
            .Include(x => x.Feature)
            .Where(x => x.VehicleID == vehicleID)
            .Select(x => x.Feature)
            .ToListAsync(cancellationToken))
            .ToFeatureResponses(mapper);
        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<VehicleResponse>>> SearchForVehicle
        (string modelName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Vehicles
            .Include(x => x.Model)
            .Where(x => x.Model.ModelName.Contains(modelName))
            .ToVehicleResponse(mapper)
            .OrderByDescending(x => x.AddDate);

        var result = await PaginatedList<VehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<VehicleStatusResponse>> StatusVehicle
        (string vehicleID, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.Vehicles.FindAsync(vehicleID, cancellationToken)) is not { } vehicle)
            return Result.Failure<VehicleStatusResponse>(VehicleErrors.NotFoundVehicle);
        var vehicleStatusResponse = vehicle.ToVehicleStatusResponse();
        return Result.Success(vehicleStatusResponse);
    }

    public async Task<Result> UpdateVehicle
        (string vehicleID, VehicleRequest vehicleRequest, CancellationToken cancellationToken = default)
    {
        if ((await appDbContext.Vehicles.FindAsync(vehicleID, cancellationToken)) is not { } vehicle)
            return Result.Failure(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id != vehicleID && x.VIN == vehicleRequest.VIN, cancellationToken))
            return Result.Failure(VehicleErrors.DuplicatedVehicleVIN);

        if (!(await appDbContext.Models.AnyAsync(x => x.Id == vehicleRequest.ModelID, cancellationToken)))
            return Result.Failure(VehicleDetailsErrors.NotFoundModel);

        if (!(await appDbContext.BodyTypes.AnyAsync(x => x.Id == vehicleRequest.BodyTypeID, cancellationToken)))
            return Result.Failure(VehicleDetailsErrors.NotFoundBodyType);

        if (vehicleRequest.FuelTypeID is not null &&
            !(await appDbContext.FuelTypes.AnyAsync(x => x.Id == vehicleRequest.FuelTypeID, cancellationToken)))
            return Result.Failure(VehicleDetailsErrors.NotfoundFuelType);

        if (!(await appDbContext.PowerTrains.AnyAsync(x => x.Id == vehicleRequest.PowerTrainID, cancellationToken)))
            return Result.Failure(VehicleDetailsErrors.NotFoundPowerTrain);

        await appDbContext.Vehicles.Where(x => x.Id == vehicleID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.VIN, vehicleRequest.VIN)
                    .SetProperty(x => x.PowerTrainID, vehicleRequest.PowerTrainID)
                    .SetProperty(x => x.TransmissionTypeID, vehicleRequest.TransmissionTypeID)
                    .SetProperty(x => x.BodyTypeID, vehicleRequest.BodyTypeID)
                    .SetProperty(x => x.ModelID, vehicleRequest.ModelID)
                    .SetProperty(x => x.RangeMiles, vehicleRequest.RangeMiles)
                    .SetProperty(x => x.InteriorColor, vehicleRequest.InteriorColor)
                    .SetProperty(x => x.ExteriorColor, vehicleRequest.ExteriorColor)
                    .SetProperty(x => x.VehiclePrice, vehicleRequest.VehiclePrice),
                cancellationToken
            );
        return Result.Success();
    }

    public async Task<Result<PaginatedList<VehicleResponse>>> VehicleByStatus
        (VehicleStatusRequest vehicleStatusRequest, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Vehicles
            .Where(x => x.VehicleStatus == vehicleStatusRequest.Status)
            .ToVehicleResponse(mapper)
            .OrderByDescending(x => x.AddDate);

        var result = await PaginatedList<VehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<List<TagResponse>>> SetTagsForVehicles
        (string vehicleID, List<TagRequest> tags, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<List<TagResponse>>(VehicleErrors.NotFoundVehicle);

        await appDbContext.VehileTags.AsNoTracking()
            .Where(x => x.VehicleID == vehicleID)
            .ExecuteDeleteAsync(cancellationToken);
        if (tags.Count == 0)
            return Result.Success(Enumerable.Empty<TagResponse>().ToList());

        var oldTags = await appDbContext.Tags.AsNoTracking()
            .Where(x => tags.Select(t => t.TagName).Contains(x.TagName))
            .ToListAsync(cancellationToken);

        var newTags = oldTags.Select(x => x.TagName)
            .Except(tags.Select(x => x.TagName))
            .Select(x => new Tag { TagName = x })
            .ToList();

        if (newTags.Any())
            await appDbContext.Tags.AddRangeAsync(newTags.ToList(), cancellationToken);

        var AllTags = oldTags.Concat(newTags);

        await appDbContext.VehileTags.AddRangeAsync(AllTags.Select(x => new VehicleTags { TagID = x.Id, VehicleID = vehicleID }).ToList(), cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(AllTags.ToTagResponses(mapper));
    }

    public async Task<Result> RemoveVehicle
        (string vehicleID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Vehicles.FindAsync(vehicleID, cancellationToken) is not { } vehicle)
            return Result.Failure(VehicleErrors.NotFoundVehicle);

        if (vehicle.VehicleStatus != VehiclesStatus.available.ToString())
            return Result.Failure(VehicleErrors.UnavailableVehicle);

        if (await appDbContext.Bookings.AnyAsync(x => x.VehicleID == vehicleID &&
            x.StartDate.Day >= DateTime.UtcNow.Day, cancellationToken))
            return Result.Failure(VehicleErrors.BookedVehicle);

        await appDbContext.Vehicles.Where(x => x.Id == vehicleID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.VehicleStatus, VehiclesStatus.none.ToString()),
                cancellationToken
            );

        return Result.Success();
    }

    public async Task<Result> RemoveFeatureForVehicle
        (string vehicleFeatureID, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.VehicleFeatures.AnyAsync(x => x.Id == vehicleFeatureID, cancellationToken)))
            return Result.Failure(VehicleErrors.NotFoundVehicleFeature);

        await appDbContext.VehicleFeatures.Where(x => x.Id == vehicleFeatureID)
            .ExecuteDeleteAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<BriefVehicleResponse>> BuyVehicle
        (BuyVehicleRequest buyVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (buyVehicleRequest is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);

        var addVehicle = await AddVehicle(buyVehicleRequest.Vehicle);
        if(addVehicle.IsFailure)
            return Result.Failure<BriefVehicleResponse>(addVehicle.Error);
        
        var doPayment = await paymentServices.DoPayment(buyVehicleRequest.Payment);
        if(doPayment.IsFailure)
            return Result.Failure<BriefVehicleResponse>(doPayment.Error);

        return Result.Success(addVehicle.Value);
    }

    public async Task<Result<ImageResponse>> AddImageForVehicle
        (string vehicleID, ImageRequest imageRequest, CancellationToken cancellationToken = default)
    {
        if (imageRequest is null)
            return Result.Failure<ImageResponse>(ImageErrors.NullImage);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure<ImageResponse>(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<ImageResponse>(VehicleErrors.UnavailableVehicle);

        var addImage = await ImageHelper.Save(imageRequest.Image, imageOptions);
        if (addImage.IsFailure)
            return Result.Failure<ImageResponse>(addImage.Error);

        var image = imageRequest.ToImage(mapper);
        image.VehicleID = vehicleID;
        image.ImageName = addImage.Value.imageName;

        await appDbContext.Images.AddAsync(image, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(image.ToImageResponse(mapper));
    }

    public async Task<Result> DeleteImageForVehicle
        (string vehicleID, string imageID, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID, cancellationToken)))
            return Result.Failure(VehicleErrors.NotFoundVehicle);

        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == vehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure(VehicleErrors.UnavailableVehicle);

        if (await appDbContext.Images.SingleOrDefaultAsync(x => x.Id == imageID, cancellationToken) is not { } image)
            return Result.Failure(ImageErrors.NotFoundImage);

        var imagePath = $"{imageOptions.Path}\\{image.ImageName}";
        var deleteImage = ImageHelper.Delete(imagePath);
        if (deleteImage.IsFailure)
            return Result.Failure<ImageResponse>(deleteImage.Error);

        await appDbContext.Images.Where(x => x.Id == imageID)
            .ExecuteDeleteAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<List<ImageResponse>>> ImagesForVehicle
        (string vehicleID, CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.Images.AsNoTracking()
            .Where(x => x.VehicleID == vehicleID)
            .ToListAsync(cancellationToken))
            .ToImageResponses(mapper);

        return Result.Success(result);
    }

    public async Task<Result<(string imagePath, string contentType)>> GetVehicleImage
        (string imageName, CancellationToken cancellationToken)
    {
        if (await appDbContext.Images.SingleOrDefaultAsync(x => x.ImageName == imageName, cancellationToken) is not { } image)
            return Result.Failure<(string, string)>(ImageErrors.NotFoundImage);

        if (!File.Exists($"{imageOptions.Path}\\{image.ImageName}"))
            return Result.Failure<(string, string)>(ImageErrors.NotFoundImage);

        var env = webHostEnvironment.WebRootPath;
        env = env.Replace("wwwroot", "");
        var imagePath = Path.Combine(imageOptions.Path, image.ImageName);
        var contentType = ImageHelper.GetContentType(imagePath);
        var fullImagePath = Path.Combine(env, imagePath);
        return Result.Success((fullImagePath, contentType));
    }


    //Private Methods   TODO : do refactoring for this code in these 3 private methods
    private async Task<Result<BriefVehicleResponse>> AddFullCombinationVehicle
        (FullCombinationVehicleRequest fullCombinationVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (fullCombinationVehicleRequest is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);

        //Model
        var modelResult = await vehicleDetailsServices.AddModel(fullCombinationVehicleRequest.Model);
        if(modelResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(modelResult.Error);

        //BodyType
        var bodyTypeResult = await vehicleDetailsServices.AddBodyType(fullCombinationVehicleRequest.BodyType);
        if (bodyTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(bodyTypeResult.Error);

        //FuelType
        var fuelTypeResult = await vehicleDetailsServices.AddFuelType(fullCombinationVehicleRequest.FuelType);
        if (fuelTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(fuelTypeResult.Error);

        //TransmissionType
        var transmissionTypeResult = await vehicleDetailsServices.AddTransmissionType(fullCombinationVehicleRequest.TransmissionType);
        if (transmissionTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(transmissionTypeResult.Error);

        //CombinationPowerTrain
        var combinatinoPowerTrainResult = await vehicleDetailsServices.AddCombinationPowerTrain(fullCombinationVehicleRequest.PowerTrain);
        if (combinatinoPowerTrainResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(combinatinoPowerTrainResult.Error);

        var vehicle = new Vehicle
        {
            VIN = fullCombinationVehicleRequest.VIN,
            ModelID = modelResult.Value.Id,
            PowerTrainID = combinatinoPowerTrainResult.Value.Id,
            TransmissionTypeID = transmissionTypeResult.Value.Id,
            BodyTypeID = bodyTypeResult.Value.Id,
            InteriorColor = fullCombinationVehicleRequest.InteriorColor,
            ExteriorColor = fullCombinationVehicleRequest.ExteriorColor,
            VehiclePrice = fullCombinationVehicleRequest.VehiclePrice
        };

        var add = await appDbContext.Vehicles.AddAsync(vehicle, cancellationToken);
        var result = await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(vehicle.ToBriefVehicleResponse(mapper));
    }

    private async Task<Result<BriefVehicleResponse>> AddFullElectricVehicle
        (FullElectricVehicleRequest fullElectricVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (fullElectricVehicleRequest is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);

        //Model
        var modelResult = await vehicleDetailsServices.AddModel(fullElectricVehicleRequest.Model);
        if (modelResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(modelResult.Error);

        //BodyType
        var bodyTypeResult = await vehicleDetailsServices.AddBodyType(fullElectricVehicleRequest.BodyType);
        if (bodyTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(bodyTypeResult.Error);

        //TransmissionType          //TODO : check is the electric vehicle has Transmission (accelerating box)
        var transmissionTypeResult = await vehicleDetailsServices.AddTransmissionType(fullElectricVehicleRequest.TransmissionType);
        if (transmissionTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(transmissionTypeResult.Error);

        //ElectricPowerTrain
        var electricVehicleResult = await vehicleDetailsServices.AddElectricPowerTrain(fullElectricVehicleRequest.PowerTrain);
        if (electricVehicleResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(electricVehicleResult.Error);

        var vehicle = new Vehicle
        {
            VIN = fullElectricVehicleRequest.VIN,
            ModelID = modelResult.Value.Id,
            PowerTrainID = electricVehicleResult.Value.Id,
            TransmissionTypeID = transmissionTypeResult.Value.Id,
            BodyTypeID = bodyTypeResult.Value.Id,
            InteriorColor = fullElectricVehicleRequest.InteriorColor,
            ExteriorColor = fullElectricVehicleRequest.ExteriorColor,
            VehiclePrice = fullElectricVehicleRequest.VehiclePrice
        };

        var add = await appDbContext.Vehicles.AddAsync(vehicle, cancellationToken);
        var result = await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(vehicle.ToBriefVehicleResponse(mapper));
    }

    private async Task<Result<BriefVehicleResponse>> AddFullHybridVehicle
        (FullHybridVehicleRequest fullHybridVehicleRequest, CancellationToken cancellationToken = default)
    {

        if (fullHybridVehicleRequest is null)
            return Result.Failure<BriefVehicleResponse>(VehicleErrors.NullVehicle);

        //Model
        var modelResult = await vehicleDetailsServices.AddModel(fullHybridVehicleRequest.Model);
        if (modelResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(modelResult.Error);

        //BodyType
        var bodyTypeResult = await vehicleDetailsServices.AddBodyType(fullHybridVehicleRequest.BodyType);
        if (bodyTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(bodyTypeResult.Error);

        //TransmissionType
        var transmissionTypeResult = await vehicleDetailsServices.AddTransmissionType(fullHybridVehicleRequest.TransmissionType);
        if (transmissionTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(transmissionTypeResult.Error);

        //FuelType
        var fuelTypeResult = await vehicleDetailsServices.AddFuelType(fullHybridVehicleRequest.FuelType);
        if (fuelTypeResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(fuelTypeResult.Error);

        //HybridPowerTrain
        var hybridVehicleResult = await vehicleDetailsServices.AddHybridPowerTrain(fullHybridVehicleRequest.PowerTrain);
        if (hybridVehicleResult.IsFailure)
            return Result.Failure<BriefVehicleResponse>(hybridVehicleResult.Error);

        var vehicle = new Vehicle
        {
            VIN = fullHybridVehicleRequest.VIN,
            ModelID = modelResult.Value.Id,
            PowerTrainID = hybridVehicleResult.Value.Id,
            TransmissionTypeID = transmissionTypeResult.Value.Id,
            BodyTypeID = bodyTypeResult.Value.Id,
            InteriorColor = fullHybridVehicleRequest.InteriorColor,
            ExteriorColor = fullHybridVehicleRequest.ExteriorColor,
            VehiclePrice = fullHybridVehicleRequest.VehiclePrice
        };

        var add = await appDbContext.Vehicles.AddAsync(vehicle, cancellationToken);
        var result = await appDbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(vehicle.ToBriefVehicleResponse(mapper));

    }

}
