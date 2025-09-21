namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles/sales")]
[ApiController]
[Authorize]
public class VehicleSalesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAllSalesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.SellServices.AllSelledVehicles(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpDelete("{sellVehicleID}")]
    public async Task<IActionResult> ReturnSelledVehicle(
        [FromRoute] string sellVehicleID,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.SellServices.ReturnSelledVehicle(sellVehicleID, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> SellVehicle(
        [FromBody] SellVehicleRequest sellVehicleRequest,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.SellServices.SellVehicle(sellVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
}
