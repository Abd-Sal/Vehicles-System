namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperRentVehicleProfile : AutoMapper.Profile
{
    public AutoMapperRentVehicleProfile()
    {
        //RentVehicle
        RentMapping();
        StopRentMapping();
        RentResponseMap();
    }
    //RentVehicle
    private void RentMapping()
        => CreateMap<RentVehicleRequest, RentVehicle>().ReverseMap();
    private void StopRentMapping()
        => CreateMap<StopRentVehicleRequest, RentVehicle>().ReverseMap();
    private void RentResponseMap()
        => CreateMap<RentVehicle, RentVehicleResponse>()
            .ForMember(dest => dest.EndAtMile, opt => opt.MapFrom(src => src.EndAtMile ?? 0))
            .ForMember(dest => dest.ActualEndRentDate, opt => opt.MapFrom(src => src.ActualEndRentDate ?? DateTime.MinValue))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount ?? 0))
            .ReverseMap();
}
