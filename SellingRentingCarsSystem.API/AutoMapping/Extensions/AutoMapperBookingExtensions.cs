namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperBookingExtensions
{
    //Booking
    public static Booking ToBookingVehicle(this BookingVehicleRequest bookingVehicleRequest, IMapper mapper)
    => mapper.Map<Booking>(bookingVehicleRequest);
    public static BookingVehicleResponse ToBookingResponse(this Booking booking, IMapper mapper)
        => mapper.Map<BookingVehicleResponse>(booking);
    public static List<BookingVehicleResponse> ToBookingResponses(this IEnumerable<Booking> bookings, IMapper mapper)
        => mapper.Map<List<BookingVehicleResponse>>(bookings);
    public static IQueryable<FullBookingVehicleResponse> ToFullBookingResponse(this IQueryable<Booking> bookings, IMapper mapper)
        => bookings.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullBookingVehicleResponse(
                x.Id,
                x.Vehicle.ToFullVehicleResponse(mapper),
                x.Customer.ToCustomerResponse(mapper),
                x.StartDate,
                x.EndDate,
                x.ExpectedAmount
            ));
}
