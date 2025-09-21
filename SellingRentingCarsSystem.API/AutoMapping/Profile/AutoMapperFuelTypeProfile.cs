namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperFuelTypeProfile : AutoMapper.Profile
{
    public AutoMapperFuelTypeProfile()
    {
        //FuelType
        FuelTypeMapping();
        FuelTypeResponseMapping();
    }
    //FuelType
    private void FuelTypeMapping()
        => CreateMap<FuelTypeRequest, FuelType>()
        .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.FuelTypeName));
    private void FuelTypeResponseMapping()
        => CreateMap<FuelType, FuelTypeResponse>();
}
