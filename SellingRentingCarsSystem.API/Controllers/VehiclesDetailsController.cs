namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details")]
[ApiController]
[Authorize]
public class VehiclesDetailsController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    //BodyType
    [HttpPost("body-types")]
    public async Task<IActionResult> AddBodyTypeAsync(
        [FromBody] BodyTypeRequest bodyTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddBodyType(bodyTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetBodyTypeById), new {bodyTypeID = temp.Value.Id}, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("body-types")]
    public async Task<IActionResult> GetAllBodyTypesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllBodyTypes(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("body-types/{bodyTypeID}")]
    public async Task<IActionResult> GetBodyTypeById(
        [FromRoute] string bodyTypeID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetBodyTypeByID(bodyTypeID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("body-types/{bodyTypeName}/by-name")]
    public async Task<IActionResult> GetBodyTypesByNameAsync(
        [FromRoute] string bodyTypeName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetBodyTypeByName(bodyTypeName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("body-types/search/{bodyTypeName}")]
    public async Task<IActionResult> SearchBodyTypesByNameAsync(
        [FromRoute] string bodyTypeName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchBodyTypesByName(bodyTypeName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("body-types/{bodyTypeID}")]
    public async Task<IActionResult> UpdateBodyTypeAsync(
        [FromRoute] string bodyTypeID,
        [FromBody] BodyTypeRequest bodyTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateBodyType(bodyTypeID, bodyTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


    //PowerTrain
    //combination
    [HttpPost("power-train/combination")]
    public async Task<IActionResult> AddCombinationPowerTrainAsync(
        [FromBody] CombinationPowerTrainRequest combinationPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddCombinationPowerTrain(combinationPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetPowerTrainById), new {powerTrainID = temp.Value.Id}, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("power-train/combination/{powerTrainID}")]
    public async Task<IActionResult> UpdateCombinationPowerTrainAsync(
        [FromRoute] string powerTrainID,
        [FromBody] UpdateCombinationPowerTrainRequest updateCombinationPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateCombinationPowerTrain(powerTrainID, updateCombinationPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    //Electric
    [HttpPost("power-train/electric")]
    public async Task<IActionResult> AddElectricPowerTrainAsync(
        [FromBody] ElectricPowerTrainRequest electricPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddElectricPowerTrain(electricPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetPowerTrainById), new { powerTrainID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("power-train/electric/{powerTrainID}")]
    public async Task<IActionResult> UpdateElectricPowerTrainAsync(
        [FromRoute] string powerTrainID,
        [FromBody] UpdateElectricPowerTrainRequest updateElectricPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateElectricPowerTrain(powerTrainID, updateElectricPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    //Hybrid
    [HttpPost("power-train/hybrid")]
    public async Task<IActionResult> AddHybridPowerTrainAsync(
    [FromBody] HybridPowerTrainRequest hybridPowerTrainRequest,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddHybridPowerTrain(hybridPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetPowerTrainById), new { powerTrainID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("power-train/hybrid/{powerTrainID}")]
    public async Task<IActionResult> UpdateHybridPowerTrainAsync(
        [FromRoute] string powerTrainID,
        [FromBody] UpdateHybridPowerTrainRequest updateHybridPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateHybridPowerTrain(powerTrainID, updateHybridPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet("power-train")]
    public async Task<IActionResult> GetAllPowerTrainsAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllPowerTrains(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("power-train/full")]
    public async Task<IActionResult> GetAllFullPowerTrains(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllFullPowerTrains(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("power-train/{powerTrainID}")]
    public async Task<IActionResult> GetPowerTrainById(
        [FromRoute] string powerTrainID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetPowerTrainByID(powerTrainID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("power-train/{powerTrainName}/by-name")]
    public async Task<IActionResult> GetPowerTrainsByNameAsync(
        [FromRoute] string powerTrainName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetPowerTrainsByName(powerTrainName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }


    //Feature
    [HttpPost("features")]
    public async Task<IActionResult> AddFeatureAsync(
    [FromBody] FeatureRequest featureRequest,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddFeature(featureRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetFeatureById), new { featureID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("features")]
    public async Task<IActionResult> GetAllFeaturesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllFeatures(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("features/{featureID}")]
    public async Task<IActionResult> GetFeatureById(
        [FromRoute] string featureID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetFeatureByID(featureID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("features/{featureName}/by-name")]
    public async Task<IActionResult> GetFeaturesBynameAsync(
        [FromRoute] string featureName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetFeatureByName(featureName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("features/search/{featureName}")]
    public async Task<IActionResult> SearchFeaturesBynameAsync(
        [FromRoute] string featureName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchFeaturesByName(featureName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("features/{featureID}")]
    public async Task<IActionResult> UpdateFeatureAsync(
        [FromRoute] string featureID,
        [FromBody] FeatureRequest featureRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateFeature(featureID, featureRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


    //FuelType
    [HttpPost("fuel-types")]
    public async Task<IActionResult> AddFuelTypeAsync(
        [FromBody] FuelTypeRequest fuelTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddFuelType(fuelTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetFuelTypeById), new { fuelTypeID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("fuel-types")]
    public async Task<IActionResult> GetAllFuelTypesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllFuelTypes(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("fuel-types/{fuelTypeID}")]
    public async Task<IActionResult> GetFuelTypeById(
        [FromRoute] string fuelTypeID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetFuelTypeByID(fuelTypeID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("fuel-types/{fuelTypeName}/by-name")]
    public async Task<IActionResult> GetFuelTypesByNameAsync(
        [FromRoute] string fuelTypeName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetFuelTypeByName(fuelTypeName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("fuel-types/search/{fuelTypeName}")]
    public async Task<IActionResult> SearchFuelTypesByNameAsync(
        [FromRoute] string fuelTypeName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchFuelTypesByName(fuelTypeName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpPut("fuel-types/{fuelTypeID}")]
    public async Task<IActionResult> UpdateFuelTypeAsync(
        [FromRoute] string fuelTypeID,
        [FromBody] FuelTypeRequest fuelTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateFuelType(fuelTypeID, fuelTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


    //Make
    [HttpPost("makes")]
    public async Task<IActionResult> AddMakeAsync(
        [FromBody] MakeRequest makeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddMake(makeRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetMakeById), new { makeID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("makes")]
    public async Task<IActionResult> GetAllMakesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllMakes(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("makes/{makeID}")]
    public async Task<IActionResult> GetMakeById(
        [FromRoute] string makeID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetMakeByID(makeID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("makes/{makeName}/by-name")]
    public async Task<IActionResult> GetMakesByNameAsync(
        [FromRoute] string makeName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetMakeByName(makeName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("makes/search/{makeName}")]
    public async Task<IActionResult> SearchMakesByNameAsync(
        [FromRoute] string makeName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchMakesByName(makeName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpPut("makes/{makeID}")]
    public async Task<IActionResult> UpdateMakeAsync(
        [FromRoute] string makeID,
        [FromBody] MakeRequest makeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateMake(makeID, makeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


    //Model
    [HttpPost("models")]
    public async Task<IActionResult> AddModelAsync(
        [FromBody] ModelRequest modelRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddModel(modelRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetModelById), new { modelID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("models")]
    public async Task<IActionResult> GetAllModelsAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllModels(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("models/full")]
    public async Task<IActionResult> GetAllFullModelsAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllFullModels(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("models/{modelID}")]
    public async Task<IActionResult> GetModelById(
        [FromRoute] string modelID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetModelByID(modelID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("models/{modelName}/by-name")]
    public async Task<IActionResult> GetModelsByNameAsync(
        [FromRoute] string modelName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetModelsByName(modelName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("models/{makeID}/by-make-id")]
    public async Task<IActionResult> GetModelsByMakeIdAsync(
        [FromRoute] string makeID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetModelsByMakeID(makeID, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("models/{modelID}")]
    public async Task<IActionResult> UpdateModelAsync(
        [FromRoute] string modelID,
        [FromBody] ModelRequest modelRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateModel(modelID, modelRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


    //FuelDelivery
    [HttpGet("fuel-delivery")]
    public async Task<IActionResult> GetAllFuelDelivery(
        [FromQuery] RequestFilters filter,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllFuelDeliveries(filter, cancellationToken);
        if(temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("fuel-delivery/{fuelDeliveryID}")]
    public async Task<IActionResult> GetFuelDeliveryByID(
        [FromRoute] string fuelDeliveryID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetFuelDeliveryByID(fuelDeliveryID, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("fuel-delivery/{fuelDeliveryName}/by-name")]
    public async Task<IActionResult> GetFuelDeliveryByName(
        [FromRoute] string fuelDeliveryName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetFuelDeliveryByName(fuelDeliveryName, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("fuel-delivery/search/{fuelDeliveryName}")]
    public async Task<IActionResult> SearchFuelDeliveryByName(
        [FromRoute] string fuelDeliveryName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchFuelDeliveriesByName(fuelDeliveryName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("fuel-delivery")]
    public async Task<IActionResult> AddFuelDelivery(
        [FromBody] FuelDeliveryRequest fuelDeliveryRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddFuelDelivery(fuelDeliveryRequest, cancellationToken);
        if (temp.IsSuccess) 
            return CreatedAtAction(nameof(GetFuelDeliveryByID), new { fuelDeliveryID = temp.Value.Id}, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("fuel-delivery/{fuelDeliveryID}")]
    public async Task<IActionResult> UpdateFuelDelivery(
        [FromRoute] string fuelDeliveryID,
        [FromBody] FuelDeliveryRequest fuelDeliveryRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateFuelDelivery(fuelDeliveryID, fuelDeliveryRequest, cancellationToken);
        if (temp.IsSuccess) 
            return NoContent();
        return temp.ToProblem();
    }


    //Aspiration
    [HttpGet("aspiration")]
    public async Task<IActionResult> GetAllAspiration(
    [FromQuery] RequestFilters filter,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllAspirations(filter, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("aspiration/{aspirationID}")]
    public async Task<IActionResult> GetAspirationByID(
        [FromRoute] string aspirationID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAspirationByID(aspirationID, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("aspiration/{aspirationName}/by-name")]
    public async Task<IActionResult> GetAspirationByName(
        [FromRoute] string aspirationName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAspirationByName(aspirationName, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("aspiration/search/{aspirationName}")]
    public async Task<IActionResult> SearchAspirationByName(
        [FromRoute] string aspirationName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchAspirationsByName(aspirationName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("aspiration")]
    public async Task<IActionResult> AddAspiration(
        [FromBody] AspirationRequest aspirationRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddAspiration(aspirationRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetAspirationByID), new { aspirationID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("aspiration/{aspirationID}")]
    public async Task<IActionResult> UpdateAspiration(
        [FromRoute] string aspirationID,
        [FromBody] AspirationRequest aspirationRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateAspirtaion(aspirationID, aspirationRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


    //ChargePort
    [HttpGet("charge-ports")]
    public async Task<IActionResult> GetAllChargePort(
    [FromQuery] RequestFilters filter,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetAllChargePorts(filter, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("charge-ports/{chargePortID}")]
    public async Task<IActionResult> GetChargePortByID(
        [FromRoute] string chargePortID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetChargePortByID(chargePortID, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("charge-ports/{chargePortName}/by-name")]
    public async Task<IActionResult> GetChargePortByName(
        [FromRoute] string chargePortName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.GetChargePortByName(chargePortName, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("charge-ports/search/{chargePortName}")]
    public async Task<IActionResult> SearchChargePortByName(
        [FromRoute] string chargePortName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.SearchChargePortsByName(chargePortName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("charge-ports")]
    public async Task<IActionResult> AddChargePort(
        [FromBody] ChargePortRequest chargePortRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.AddChargePort(chargePortRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetChargePortByID), new { chargePortID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("charge-ports/{chargePortID}")]
    public async Task<IActionResult> UpdateChargePort(
        [FromRoute] string chargePortID,
        [FromBody] ChargePortRequest chargePortRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsServices.UpdateChargePort(chargePortID, chargePortRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }


}
