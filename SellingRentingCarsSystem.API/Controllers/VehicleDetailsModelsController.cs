namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/models")]
[ApiController]
[Authorize]
public class VehicleDetailsModelsController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> AddModelAsync(
        [FromBody] ModelRequest modelRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.AddModel(modelRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetModelById), new { modelID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllModelsAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.GetAllModels(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("full")]
    public async Task<IActionResult> GetAllFullModelsAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.GetAllFullModels(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{modelID}")]
    public async Task<IActionResult> GetModelById(
        [FromRoute] string modelID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.GetModelByID(modelID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{modelName}/by-name")]
    public async Task<IActionResult> GetModelsByNameAsync(
        [FromRoute] string modelName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.GetModelsByName(modelName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{makeID}/by-make-id")]
    public async Task<IActionResult> GetModelsByMakeIdAsync(
        [FromRoute] string makeID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.GetModelsByMakeID(makeID, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{modelID}")]
    public async Task<IActionResult> UpdateModelAsync(
        [FromRoute] string modelID,
        [FromBody] ModelRequest modelRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsModelServices.UpdateModel(modelID, modelRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
