namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/transmission-types")]
[ApiController]
public class VehicleDetailsTransmissionTypesController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    [HttpPost]
    public async Task<IActionResult> AddTransmissionType(
        [FromBody] TransmissionTypeRequest transmissionTypeRequest,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleDetailsTransmissionTypeServices.AddTransmissionType(transmissionTypeRequest, cancellationToken);
        if(temp.IsSuccess)
            return CreatedAtAction(nameof(GetTransmissionTypeByID), new { id = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransmissionType(
        [FromRoute] string id,
        [FromBody] TransmissionTypeRequest transmissionTypeRequest,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleDetailsTransmissionTypeServices.UpdateTransmissionType(id, transmissionTypeRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransmissionType(
        [FromQuery] RequestFilters requestFilters,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleDetailsTransmissionTypeServices.GetAllTransmissionTypes(requestFilters, cancellationToken);
        if (temp.IsSuccess)
            return  Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransmissionTypeByID(
        [FromRoute] string id,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleDetailsTransmissionTypeServices.GetTransmissionTypeByID(id, cancellationToken);
        if (temp.IsSuccess)
            return  Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{name}/by-name")]
    public async Task<IActionResult> GetTransmissionTypeByName(
        [FromRoute] string name,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleDetailsTransmissionTypeServices.GetTransmissionTypeByName(name, cancellationToken);
        if (temp.IsSuccess)
            return  Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{name}")]
    public async Task<IActionResult> SearchTransmissionTypeByName(
        [FromRoute] string name,
        [FromQuery] RequestFilters requestFilters,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleDetailsTransmissionTypeServices.SearchTransmissionTypesByName(name, requestFilters, cancellationToken);
        if (temp.IsSuccess)
            return  Ok(temp.Value);
        return temp.ToProblem();
    }
}
