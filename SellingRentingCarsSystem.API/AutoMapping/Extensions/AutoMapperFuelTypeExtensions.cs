namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperFuelTypeExtensions
{
    //FuelType
    public static FuelType ToFuelType(this FuelTypeRequest fuelTypeRequest, IMapper mapper)
        => mapper.Map<FuelType>(fuelTypeRequest);
    public static FuelTypeResponse ToFuelTypeResponse(this FuelType fuelType, IMapper mapper)
        => mapper.Map<FuelTypeResponse>(fuelType);
    public static List<FuelTypeResponse> ToFuelTypeResponses(this IEnumerable<FuelType> fuelTypes, IMapper mapper)
        => mapper.Map<List<FuelTypeResponse>>(fuelTypes);
}
