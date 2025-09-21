namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles-details/features")]
[ApiController]
[Authorize]
public class VehicleDetailsFeaturesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> AddFeatureAsync(
    [FromBody] FeatureRequest featureRequest,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFeatureServices.AddFeature(featureRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(nameof(GetFeatureById), new { featureID = temp.Value.Id }, temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFeaturesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFeatureServices.GetAllFeatures(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{featureID}")]
    public async Task<IActionResult> GetFeatureById(
        [FromRoute] string featureID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFeatureServices.GetFeatureByID(featureID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{featureName}/by-name")]
    public async Task<IActionResult> GetFeaturesBynameAsync(
        [FromRoute] string featureName,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFeatureServices.GetFeatureByName(featureName, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{featureName}")]
    public async Task<IActionResult> SearchFeaturesBynameAsync(
        [FromRoute] string featureName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFeatureServices.SearchFeaturesByName(featureName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{featureID}")]
    public async Task<IActionResult> UpdateFeatureAsync(
        [FromRoute] string featureID,
        [FromBody] FeatureRequest featureRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleDetailsFeatureServices.UpdateFeature(featureID, featureRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

}
