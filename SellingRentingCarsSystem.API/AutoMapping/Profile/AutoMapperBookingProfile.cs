namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperBookingProfile : AutoMapper.Profile
{
    public AutoMapperBookingProfile()
    {
        //Booking
        BookingMapping();
        BookingResponseMapping();
    }
    //Booking
    private void BookingMapping()
        => CreateMap<BookingVehicleRequest, Booking>().ReverseMap();
    private void BookingResponseMapping()
        => CreateMap<Booking, BookingVehicleResponse>().ReverseMap();
}
