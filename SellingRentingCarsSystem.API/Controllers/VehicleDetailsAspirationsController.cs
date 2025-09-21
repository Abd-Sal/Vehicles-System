namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/aspiration")]
[ApiController]
[Authorize]
public class VehicleDetailsAspirationsController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAllAspiration(
    [FromQuery] RequestFilters filter,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsAspirationServices.GetAllAspirations(filter, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{aspirationID}")]
    public async Task<IActionResult> GetAspirationByID(
        [FromRoute] string aspirationID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsAspirationServices.GetAspirationByID(aspirationID, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{aspirationName}/by-name")]
    public async Task<IActionResult> GetAspirationByName(
        [FromRoute] string aspirationName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsAspirationServices.GetAspirationByName(aspirationName, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{aspirationName}")]
    public async Task<IActionResult> SearchAspirationByName(
        [FromRoute] string aspirationName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsAspirationServices.SearchAspirationsByName(aspirationName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> AddAspiration(
        [FromBody] AspirationRequest aspirationRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsAspirationServices.AddAspiration(aspirationRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetAspirationByID), new { aspirationID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{aspirationID}")]
    public async Task<IActionResult> UpdateAspiration(
        [FromRoute] string aspirationID,
        [FromBody] AspirationRequest aspirationRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsAspirationServices.UpdateAspirtaion(aspirationID, aspirationRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
