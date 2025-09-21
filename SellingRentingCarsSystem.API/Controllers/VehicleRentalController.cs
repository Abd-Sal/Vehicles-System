namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles/rents")]
[ApiController]
[Authorize]
public class VehicleRentalController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;


    [HttpPost("start")]
    public async Task<IActionResult> StartRentVehicle(
        [FromBody] RentVehicleRequest rentVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.StartRentVehicle(rentVehicleRequest, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("stop")]
    public async Task<IActionResult> StopRentVehicle(
        [FromBody] StopRentVehicleRequest stopRentVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.StopRentVehicle(stopRentVehicleRequest, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> CurrentRentedVehicle(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.CurrentRentingVehicle(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}")]
    public async Task<IActionResult> GetRentHistoryForVehicle(
        [FromRoute] string vehicleID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.RentHistoryForVehicle(vehicleID, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("today")]
    public async Task<IActionResult> GetVehicleEndRentToday(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.VehicleEndRentToday(filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

}
