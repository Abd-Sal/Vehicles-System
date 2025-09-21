namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperSellVehicleExtensions
{

    //SellVehicle
    public static SellVehicle ToSellVehicle(this SellVehicleRequest sellVehicleRequest, IMapper mapper)
        => mapper.Map<SellVehicle>(sellVehicleRequest);
    public static SellVehicleResponse ToSellVehicleResponse(this SellVehicle sellVehicle, IMapper mapper)
        => mapper.Map<SellVehicleResponse>(sellVehicle);
    public static List<SellVehicleResponse> ToSellVehicleResponses(this IEnumerable<SellVehicle> sellVehicles, IMapper mapper)
        => mapper.Map<List<SellVehicleResponse>>(sellVehicles);
    public static IQueryable<FullSellVehicleResponse> ToFullSellVehicleResponses(this IQueryable<SellVehicle> sellVehicles, IMapper mapper)
        => sellVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullSellVehicleResponse(
                x.Id,
                x.Vehicle.ToFullVehicleResponse(mapper),
                x.Customer.ToCustomerResponse(mapper),
                x.SellDate,
                x.Payment.ToPaymentResponse(mapper)
            ));

}
