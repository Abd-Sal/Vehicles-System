namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/makes")]
[ApiController]
[Authorize]
public class VehicleDetailsMakesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> AddMakeAsync(
        [FromBody] MakeRequest makeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsMakeServices.AddMake(makeRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetMakeById), new { makeID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMakesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsMakeServices.GetAllMakes(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{makeID}")]
    public async Task<IActionResult> GetMakeById(
        [FromRoute] string makeID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsMakeServices.GetMakeByID(makeID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{makeName}/by-name")]
    public async Task<IActionResult> GetMakesByNameAsync(
        [FromRoute] string makeName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsMakeServices.GetMakeByName(makeName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{makeName}")]
    public async Task<IActionResult> SearchMakesByNameAsync(
        [FromRoute] string makeName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsMakeServices.SearchMakesByName(makeName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{makeID}")]
    public async Task<IActionResult> UpdateMakeAsync(
        [FromRoute] string makeID,
        [FromBody] MakeRequest makeRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsMakeServices.UpdateMake(makeID, makeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
