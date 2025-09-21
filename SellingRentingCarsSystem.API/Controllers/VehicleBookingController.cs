namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/vehicles/books")]
[ApiController]
[Authorize]
public class VehicleBookingController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> BookingVehicle(
        [FromBody] BookingVehicleRequest bookingVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.BookingVehicle(bookingVehicleRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{isCanceled}/{isDone}")]
    public async Task<IActionResult> GetBooksForVehicleInRangeDate(
        [FromBody] CheckBookingDateRequest checkBookingDateRequest,
        [FromQuery] RequestFilters filters,
        [FromRoute] bool isCanceled = true,
        [FromRoute] bool isDone = true,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.GetBooksForVehicleInRangeDate(checkBookingDateRequest, isCanceled, isDone, filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("check")]
    public async Task<IActionResult> CheckBooksForVehicleInRangeDate(
        [FromBody] CheckBookingDateRequest checkBookingDateRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.CheckBooksForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("{bookVehicleID}")]
    public async Task<IActionResult> CancelBookForVehicle(
        [FromRoute] string bookVehicleID,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.CancelBookingVehicle(bookVehicleID, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpPut("{bookVehicleID}")]
    public async Task<IActionResult> UpdateBookVehicle(
        [FromRoute] string bookVehicleID,
        [FromBody] UpdateBookingVehicleRequest updateBookingVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.UpdateBookingVehicle(bookVehicleID, updateBookingVehicleRequest, cancellationToken);
        if (temp.IsSuccess) return NoContent();
        return temp.ToProblem();
    }

    [HttpPost("cancel-range-date")]
    public async Task<IActionResult> CancelBookForVehicleByRangeDate(
        [FromBody] CheckBookingDateRequest checkBookingDateRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.CancelBookingForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);
        if (temp.IsSuccess)
            return NoContent();
        return temp.ToProblem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicleBooks(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.BookingServices.VehicleBooking(filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }

}
