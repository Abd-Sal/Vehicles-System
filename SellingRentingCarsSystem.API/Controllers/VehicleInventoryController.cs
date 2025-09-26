namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles")]
[ApiController]
[Authorize]
public class VehicleInventoryController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> AddVehicleAsync(
        [FromBody] VehicleRequest vehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddVehicle(vehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{vehicleID}")]
    public async Task<IActionResult> UpdateVehicleAsync(
        [FromRoute] string vehicleID,
        [FromBody] VehicleRequest vehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.UpdateVehicle(vehicleID, vehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet("{availableOnly}")]
    public async Task<IActionResult> GetAllVehiclesAsync(
        [FromRoute] bool availableOnly,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetAllVehicles(availableOnly, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/{availableOnly}")]
    public async Task<IActionResult> GetVehicleByIDAsync(
        [FromRoute] string vehicleID,
        [FromRoute] bool availableOnly,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehicle(vehicleID, availableOnly, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{modelName}")]
    public async Task<IActionResult> SearchForVehicleByModelNameAsync(
        [FromRoute] string modelName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.SearchForVehicle(modelName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("{vehicleID}/features")]
    public async Task<IActionResult> AddFeatureForVehicleAsync(
        [FromRoute] string vehicleID,
        [FromBody] VehicleFeatureRequest vehicleFeatureRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddFeatureForVehicle(vehicleID, vehicleFeatureRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }


    [HttpGet("by-power-train-type/{availableOnly}")]
    public async Task<IActionResult> GetVehiclesByPowerTrainTypeAsync(
        [FromRoute] bool availableOnly,
        [FromBody] VehiclePowerTrainRequest vehiclePowerTrainRequest,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehiclesByPowerTrainType(vehiclePowerTrainRequest, availableOnly, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("by-power-train-id/{powerTrainID}/{availableOnly}")]
    public async Task<IActionResult> GetVehiclesByPowerTrainIDAsync(
        [FromRoute] string powerTrainID,
        [FromRoute] bool availableOnly,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehiclesByPowerTrainID(powerTrainID, availableOnly, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/features")]
    public async Task<IActionResult> GetFeaturesForVehicleAsync(
        [FromRoute] string vehicleID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetFeaturesForVehicle(vehicleID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/get-status")]
    public async Task<IActionResult> GetStatusForVehicleByIDAsync(
        [FromRoute] string vehicleID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.StatusVehicle(vehicleID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetVehiclesByStatusAsync(
        [FromBody] VehicleStatusRequest vehicleStatusRequest,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.VehicleByStatus(vehicleStatusRequest, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    public async Task<IActionResult> SetTagsForVehicle(
        [FromRoute] string vehicleID,
        [FromBody] List<TagRequest> tagRequests,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.SetTagsForVehicles(vehicleID, tagRequests, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
}
