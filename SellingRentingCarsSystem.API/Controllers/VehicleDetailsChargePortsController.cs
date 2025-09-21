namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/charge-ports")]
[ApiController]
[Authorize]
public class VehicleDetailsChargePortsController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAllChargePort(
    [FromQuery] RequestFilters filter,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsChargePortServices.GetAllChargePorts(filter, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{chargePortID}")]
    public async Task<IActionResult> GetChargePortByID(
        [FromRoute] string chargePortID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsChargePortServices.GetChargePortByID(chargePortID, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{chargePortName}/by-name")]
    public async Task<IActionResult> GetChargePortByName(
        [FromRoute] string chargePortName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsChargePortServices.GetChargePortByName(chargePortName, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{chargePortName}")]
    public async Task<IActionResult> SearchChargePortByName(
        [FromRoute] string chargePortName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsChargePortServices.SearchChargePortsByName(chargePortName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> AddChargePort(
        [FromBody] ChargePortRequest chargePortRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsChargePortServices.AddChargePort(chargePortRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetChargePortByID), new { chargePortID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{chargePortID}")]
    public async Task<IActionResult> UpdateChargePort(
        [FromRoute] string chargePortID,
        [FromBody] ChargePortRequest chargePortRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsChargePortServices.UpdateChargePort(chargePortID, chargePortRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
