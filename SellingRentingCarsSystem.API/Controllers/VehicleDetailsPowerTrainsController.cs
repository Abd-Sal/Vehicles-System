namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/power-train")]
[ApiController]
[Authorize]
public class VehicleDetailsPowerTrainsController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    //combination
    [HttpPost("combination")]
    public async Task<IActionResult> AddCombinationPowerTrainAsync(
        [FromBody] CombinationPowerTrainRequest combinationPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.AddCombinationPowerTrain(combinationPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetPowerTrainById), new { powerTrainID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("combination/{powerTrainID}")]
    public async Task<IActionResult> UpdateCombinationPowerTrainAsync(
        [FromRoute] string powerTrainID,
        [FromBody] UpdateCombinationPowerTrainRequest updateCombinationPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.UpdateCombinationPowerTrain(powerTrainID, updateCombinationPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    //Electric
    [HttpPost("electric")]
    public async Task<IActionResult> AddElectricPowerTrainAsync(
        [FromBody] ElectricPowerTrainRequest electricPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.AddElectricPowerTrain(electricPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetPowerTrainById), new { powerTrainID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("electric/{powerTrainID}")]
    public async Task<IActionResult> UpdateElectricPowerTrainAsync(
        [FromRoute] string powerTrainID,
        [FromBody] UpdateElectricPowerTrainRequest updateElectricPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.UpdateElectricPowerTrain(powerTrainID, updateElectricPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    //Hybrid
    [HttpPost("hybrid")]
    public async Task<IActionResult> AddHybridPowerTrainAsync(
    [FromBody] HybridPowerTrainRequest hybridPowerTrainRequest,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.AddHybridPowerTrain(hybridPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetPowerTrainById), new { powerTrainID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("hybrid/{powerTrainID}")]
    public async Task<IActionResult> UpdateHybridPowerTrainAsync(
        [FromRoute] string powerTrainID,
        [FromBody] UpdateHybridPowerTrainRequest updateHybridPowerTrainRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.UpdateHybridPowerTrain(powerTrainID, updateHybridPowerTrainRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPowerTrainsAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.GetAllPowerTrains(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("full")]
    public async Task<IActionResult> GetAllFullPowerTrains(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.GetAllFullPowerTrains(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{powerTrainID}")]
    public async Task<IActionResult> GetPowerTrainById(
        [FromRoute] string powerTrainID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.GetPowerTrainByID(powerTrainID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{powerTrainName}/by-name")]
    public async Task<IActionResult> GetPowerTrainsByNameAsync(
        [FromRoute] string powerTrainName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsPowerTrainServices.GetPowerTrainsByName(powerTrainName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

}
