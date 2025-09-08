namespace SellingRentingCarsSystem.API.Interfaces;

public interface IBookingServices
{
    Task<Result<List<BookingVehicleResponse>>> GetBooksForVehicleInRangeDate(CheckBookingDateRequest checkBookingDateRequest, bool isCanceled = true, bool isDone = true, CancellationToken cancellationToken = default);
    Task<Result<bool>> CheckBooksForVehicleInRangeDate(CheckBookingDateRequest checkBookingDateRequest, CancellationToken cancellationToken = default);
    Task<Result<BookingVehicleResponse>> BookingVehicle(BookingVehicleRequest bookingVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> UpdateBookingVehicle(string bookingVehicleID, UpdateBookingVehicleRequest updateBookingVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> CancelBookingVehicle(string bookingVehicleID, CancellationToken cancellationToken = default);
    Task<Result<List<BriefVehicleResponse>>> VehicleBooking(CancellationToken cancellationToken = default);
    Task<Result> CancelBookingForVehicleInRangeDate(CheckBookingDateRequest checkBookingDateRequest, CancellationToken cancellationToken = default);
}
