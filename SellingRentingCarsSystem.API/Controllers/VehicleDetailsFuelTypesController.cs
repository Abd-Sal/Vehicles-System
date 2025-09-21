namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/fuel-types")]
[ApiController]
[Authorize]
public class VehicleDetailsFuelTypesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> AddFuelTypeAsync(
        [FromBody] FuelTypeRequest fuelTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelTypeServices.AddFuelType(fuelTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetFuelTypeById), new { fuelTypeID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFuelTypesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelTypeServices.GetAllFuelTypes(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{fuelTypeID}")]
    public async Task<IActionResult> GetFuelTypeById(
        [FromRoute] string fuelTypeID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelTypeServices.GetFuelTypeByID(fuelTypeID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{fuelTypeName}/by-name")]
    public async Task<IActionResult> GetFuelTypesByNameAsync(
        [FromRoute] string fuelTypeName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelTypeServices.GetFuelTypeByName(fuelTypeName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{fuelTypeName}")]
    public async Task<IActionResult> SearchFuelTypesByNameAsync(
        [FromRoute] string fuelTypeName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelTypeServices.SearchFuelTypesByName(fuelTypeName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{fuelTypeID}")]
    public async Task<IActionResult> UpdateFuelTypeAsync(
        [FromRoute] string fuelTypeID,
        [FromBody] FuelTypeRequest fuelTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFuelTypeServices.UpdateFuelType(fuelTypeID, fuelTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
