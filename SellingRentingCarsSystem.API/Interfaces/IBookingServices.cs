namespace SellingRentingCarsSystem.API.Interfaces;

public interface IBookingServices
{
    Task<Result<PaginatedList<FullBookingVehicleResponse>>> GetBooksForVehicleInRangeDate(CheckBookingDateRequest checkBookingDateRequest, bool isCanceled, bool isDone, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<bool>> CheckBooksForVehicleInRangeDate(CheckBookingDateRequest checkBookingDateRequest, CancellationToken cancellationToken = default);
    Task<Result<BookingVehicleResponse>> BookingVehicle(BookingVehicleRequest bookingVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> UpdateBookingVehicle(string bookingVehicleID, UpdateBookingVehicleRequest updateBookingVehicleRequest, CancellationToken cancellationToken = default);
    Task<Result> CancelBookingVehicle(string bookingVehicleID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullBookingVehicleResponse>>> VehicleBooking(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result> CancelBookingForVehicleInRangeDate(CheckBookingDateRequest checkBookingDateRequest, CancellationToken cancellationToken = default);
}
