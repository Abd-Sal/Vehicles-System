namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperAspirationExtensions
{
    //Aspiration
    public static Aspiration ToAspiration(this AspirationRequest aspirationRequest, IMapper mapper)
        => mapper.Map<Aspiration>(aspirationRequest);
    public static AspirationResponse ToAspirationResponse(this Aspiration aspiration, IMapper mapper)
        => mapper.Map<AspirationResponse>(aspiration);

}
