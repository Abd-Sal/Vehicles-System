namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/fuel-delivery")]
[ApiController]
[Authorize]
public class VehicleDetailsFuelDeliveriesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAllFuelDelivery(
        [FromQuery] RequestFilters filter,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelDeliveryServices.GetAllFuelDeliveries(filter, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{fuelDeliveryID}")]
    public async Task<IActionResult> GetFuelDeliveryByID(
        [FromRoute] string fuelDeliveryID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelDeliveryServices.GetFuelDeliveryByID(fuelDeliveryID, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{fuelDeliveryName}/by-name")]
    public async Task<IActionResult> GetFuelDeliveryByName(
        [FromRoute] string fuelDeliveryName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelDeliveryServices.GetFuelDeliveryByName(fuelDeliveryName, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{fuelDeliveryName}")]
    public async Task<IActionResult> SearchFuelDeliveryByName(
        [FromRoute] string fuelDeliveryName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelDeliveryServices.SearchFuelDeliveriesByName(fuelDeliveryName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> AddFuelDelivery(
        [FromBody] FuelDeliveryRequest fuelDeliveryRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelDeliveryServices.AddFuelDelivery(fuelDeliveryRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetFuelDeliveryByID), new { fuelDeliveryID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{fuelDeliveryID}")]
    public async Task<IActionResult> UpdateFuelDelivery(
        [FromRoute] string fuelDeliveryID,
        [FromBody] FuelDeliveryRequest fuelDeliveryRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelDeliveryServices.UpdateFuelDelivery(fuelDeliveryID, fuelDeliveryRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
