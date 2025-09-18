namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles")]
[ApiController]
[Authorize]
public class VehiclesController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    //Vehicles
    [HttpPost()]
    public async Task<IActionResult> AddVehicleAsync(
        [FromBody] VehicleRequest vehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddVehicle(vehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("combination-vehicles")]
    public async Task<IActionResult> AddFullCombinationVehicleAsync(
        [FromBody] FullCombinationVehicleRequest fullCombinationVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddFullVehicle(fullCombinationVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("electric-vehicles")]
    public async Task<IActionResult> AddFullElectricVehicleAsync(
        [FromBody] FullElectricVehicleRequest fullElectricVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddFullVehicle(fullElectricVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("hybrid-vehicles")]
    public async Task<IActionResult> AddFullHybridVehicleAsync(
        [FromBody] FullHybridVehicleRequest fullHybridVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddFullVehicle(fullHybridVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("{vehicleID}/features")]
    public async Task<IActionResult> AddFeatureForVehicleAsync(
        [FromRoute] string vehicleID,
        [FromBody] VehicleFeatureRequest vehicleFeatureRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.AddFeatureForVehicle(vehicleID, vehicleFeatureRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{availableOnly}")]
    public async Task<IActionResult> GetAllVehiclesAsync(
        [FromRoute] bool availableOnly,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetAllVehicles(availableOnly, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("by-power-train-type/{availableOnly}")]
    public async Task<IActionResult> GetVehiclesByPowerTrainTypeAsync(
        [FromRoute] bool availableOnly,
        [FromBody] VehiclePowerTrainRequest vehiclePowerTrainRequest,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehiclesByPowerTrainType(vehiclePowerTrainRequest, availableOnly, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("by-power-train-id/{powerTrainID}/{availableOnly}")]
    public async Task<IActionResult> GetVehiclesByPowerTrainIDAsync(
        [FromRoute] string powerTrainID,
        [FromRoute] bool availableOnly,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehiclesByPowerTrainID(powerTrainID, availableOnly, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
 
    [HttpGet("{vehicleID}/{availableOnly}")]
    public async Task<IActionResult> GetVehicleByIDAsync(
        [FromRoute] string vehicleID,
        [FromRoute] bool availableOnly,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetVehicle(vehicleID, availableOnly, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/features")]
    public async Task<IActionResult> GetFeaturesForVehicleAsync(
        [FromRoute] string vehicleID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.GetFeaturesForVehicle(vehicleID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("search/{modelName}")]
    public async Task<IActionResult> SearchForVehicleByModelNameAsync(
        [FromRoute] string modelName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.SearchForVehicle(modelName, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/get-status")]
    public async Task<IActionResult> GetStatusForVehicleByIDAsync(
        [FromRoute] string vehicleID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.StatusVehicle(vehicleID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetVehiclesByStatusAsync(
        [FromBody] VehicleStatusRequest vehicleStatusRequest,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.VehicleByStatus(vehicleStatusRequest, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{vehicleID}")]
    public async Task<IActionResult> UpdateVehicleAsync(
        [FromRoute] string vehicleID,
        [FromBody] VehicleRequest vehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.UpdateVehicle(vehicleID, vehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet("{vehicleID}/images")]
    public async Task<IActionResult> GetVehicleImagesAsync(
        [FromRoute] string vehicleID,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.VehicleServices.ImagesForVehicle(vehicleID, cancellationToken);
        if(temp.IsSuccess)
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
        if(temp.IsSuccess)
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
        if(temp.IsSuccess)
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


    //Maintenance
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


    //Sales
    [HttpGet("sales")]
    public async Task<IActionResult> GetAllSalesAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.SellServices.AllSelledVehicles(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpDelete("sales/{sellVehicleID}")]
    public async Task<IActionResult> ReturnSelledVehicle(
        [FromRoute] string sellVehicleID,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.SellServices.ReturnSelledVehicle(sellVehicleID, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }
    
    [HttpPost("sales")]
    public async Task<IActionResult> SellVehicle(
        [FromBody] SellVehicleRequest sellVehicleRequest,
        CancellationToken cancellationToken)
    {
        var temp = await unitOfWork.SellServices.SellVehicle(sellVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }


    //Booking
    [HttpPost("books")]
    public async Task<IActionResult> BookingVehicle(
        [FromBody] BookingVehicleRequest bookingVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.BookingVehicle(bookingVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("books/{isCanceled}/{isDone}")]
    public async Task<IActionResult> GetBooksForVehicleInRangeDate(
        [FromBody] CheckBookingDateRequest checkBookingDateRequest,
        [FromQuery] RequestFilters filters,
        [FromRoute] bool isCanceled = true,
        [FromRoute] bool isDone = true,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.GetBooksForVehicleInRangeDate(checkBookingDateRequest, isCanceled, isDone, filters, cancellationToken);
        if(temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("books/check")]
    public async Task<IActionResult> CheckBooksForVehicleInRangeDate(
        [FromBody] CheckBookingDateRequest checkBookingDateRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.CheckBooksForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);
        if(temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("books/{bookVehicleID}")]
    public async Task<IActionResult> CancelBookForVehicle(
        [FromRoute] string bookVehicleID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.CancelBookingVehicle(bookVehicleID, cancellationToken);
        if(temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpPost("books/cancel-range-date")]
    public async Task<IActionResult> CancelBookForVehicleByRangeDate(
        [FromBody] CheckBookingDateRequest checkBookingDateRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.CancelBookingForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);
        if(temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpPut("books/{bookVehicleID}")]
    public async Task<IActionResult> UpdateBookVehicle(
        [FromRoute] string bookVehicleID,
        [FromBody] UpdateBookingVehicleRequest updateBookingVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.UpdateBookingVehicle(bookVehicleID, updateBookingVehicleRequest, cancellationToken);
        if (temp.IsSuccess) return NoContent();
        return temp.ToProblem(); 
    }

    [HttpGet("books")]
    public async Task<IActionResult> GetAllVehicleBooks(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.VehicleBooking(filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }


    //Renting
    [HttpGet("rents/{vehicleID}")]
    public async Task<IActionResult> GetRentHistoryForVehicle(
        [FromRoute] string vehicleID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.RentHistoryForVehicle(vehicleID, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("rents/start")]
    public async Task<IActionResult> StartRentVehicle(
        [FromBody] RentVehicleRequest rentVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.StartRentVehicle(rentVehicleRequest, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("rents/stop")]
    public async Task<IActionResult> StopRentVehicle(
        [FromBody] StopRentVehicleRequest stopRentVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.StopRentVehicle(stopRentVehicleRequest, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("rents")]
    public async Task<IActionResult> CurrentRentedVehicle(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.CurrentRentingVehicle(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("rents/today")]
    public async Task<IActionResult> GetVehicleEndRentToday(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.RentServices.VehicleEndRentToday(filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

    //Tags
    public async Task<IActionResult> SetTagsForVehicle(
        [FromRoute] string vehicleID,
        [FromBody] List<TagRequest> tagRequests,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.VehicleServices.SetTagsForVehicles(vehicleID, tagRequests, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }
}
