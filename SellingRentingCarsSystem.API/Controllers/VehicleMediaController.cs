namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles")]
[ApiController]
[Authorize]
public class VehicleMediaController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpGet("{vehicleID}/images")]
    public async Task<IActionResult> GetVehicleImagesAsync(
        [FromRoute] string vehicleID,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleServices.ImagesForVehicle(vehicleID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("{vehicleID}/images")]
    public async Task<IActionResult> AddVehicleImageAsync(
        [FromRoute] string vehicleID,
        [FromRoute] ImageRequest imageRequest,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleServices.AddImageForVehicle(vehicleID, imageRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpDelete("{vehicleID}/images/{imageID}")]
    public async Task<IActionResult> DeleteVehicleImageAsync(
        [FromRoute] string vehicleID,
        [FromRoute] string imageID,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleServices.DeleteImageForVehicle(vehicleID, imageID, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet("images/{imageName}")]
    public async Task<IActionResult> GetVehicleImage(
    [FromRoute] string imageName,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehicleImage(imageName, cancellationToken);
        if (temp.IsSuccess)
            return PhysicalFile(temp.Value.imagePath, temp.Value.contentType);
        return temp.ToProblem();
    }
}
