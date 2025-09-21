namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles")]
[ApiController]
[Authorize]
public class VehicleMaintenanceController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost("enter-to-maintenance/{vehicleID}/{days}")]
    public async Task<IActionResult> PutVehicleInMaintenanceAsync(
        [FromRoute] string vehicleID,
        [FromRoute] int days,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.MaintenanceServices.PutVehicleInMaintenance(vehicleID, days, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpPost("finish-maintenance/{vehicleID}")]
    public async Task<IActionResult> MaintenanceForVehicleAsync(
        [FromBody] MaintenanceRequest maintenanceRequest,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.MaintenanceServices.MaintenanceForVehicle(maintenanceRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/maintenance")]
    public async Task<IActionResult> GetMaintenancesForVehicleAsync(
        [FromRoute] string vehicleID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.MaintenanceServices.GetMaintenancesForVehicleAsync(vehicleID, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

}
