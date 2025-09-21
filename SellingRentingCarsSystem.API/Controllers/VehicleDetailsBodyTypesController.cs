namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/body-types")]
[ApiController]
[Authorize]
public class VehicleDetailsBodyTypesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> AddBodyTypeAsync(
    [FromBody] BodyTypeRequest bodyTypeRequest,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsBodyTypeServices.AddBodyType(bodyTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetBodyTypeById), new { bodyTypeID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBodyTypesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsBodyTypeServices.GetAllBodyTypes(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{bodyTypeID}")]
    public async Task<IActionResult> GetBodyTypeById(
        [FromRoute] string bodyTypeID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsBodyTypeServices.GetBodyTypeByID(bodyTypeID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{bodyTypeName}/by-name")]
    public async Task<IActionResult> GetBodyTypesByNameAsync(
        [FromRoute] string bodyTypeName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsBodyTypeServices.GetBodyTypeByName(bodyTypeName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{bodyTypeName}")]
    public async Task<IActionResult> SearchBodyTypesByNameAsync(
        [FromRoute] string bodyTypeName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsBodyTypeServices.SearchBodyTypesByName(bodyTypeName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{bodyTypeID}")]
    public async Task<IActionResult> UpdateBodyTypeAsync(
        [FromRoute] string bodyTypeID,
        [FromBody] BodyTypeRequest bodyTypeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsBodyTypeServices.UpdateBodyType(bodyTypeID, bodyTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
