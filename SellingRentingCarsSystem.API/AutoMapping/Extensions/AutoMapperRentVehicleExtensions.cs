namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperRentVehicleExtensions
{
    //RentVehicle
    public static RentVehicle ToRentVehicle(this RentVehicleRequest rentVehicleRequest, IMapper mapper)
        => mapper.Map<RentVehicle>(rentVehicleRequest);
    public static RentVehicle ToRentVehicle(this StopRentVehicleRequest stopRentVehicleRequest, IMapper mapper)
        => mapper.Map<RentVehicle>(stopRentVehicleRequest);
    public static RentVehicleResponse ToRentVehicleResponse(this RentVehicle rentVehicle, IMapper mapper)
        => mapper.Map<RentVehicleResponse>(rentVehicle);
    public static List<RentVehicleResponse> ToRentVehicleResponses(this IEnumerable<RentVehicle> rentVehicles, IMapper mapper)
        => mapper.Map<List<RentVehicleResponse>>(rentVehicles);
    public static IQueryable<FullRentVehicleResponse> ToFullRentVehicleResponses(this IQueryable<RentVehicle> rentVehicles, IMapper mapper)
        => rentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.Images)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
        .Select(x => new FullRentVehicleResponse(
            x.Id,
            x.Vehicle.ToFullVehicleResponse(mapper),
            x.Customer.ToCustomerResponse(mapper),
            x.StartAtMile,
            x.EndAtMile != null ? (int)x.EndAtMile : default,
            x.StartRentDate,
            x.ExpectedEndRentDate,
            x.ActualEndRentDate != null ? (DateTime)x.ActualEndRentDate : default,
            x.ExpectedAmount,
            x.DamageAmount,
            x.DamageDescription,
            x.Amount != null ? (int)x.Amount : default,
            x.PayLater,
            x.Payment!.ToPaymentResponse(mapper)
        ));
    public static IQueryable<FullRentedVehicleResponse> ToFullRentedVehicleResponses(this IQueryable<RentVehicle> rentVehicles, IMapper mapper)
        => rentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.Images)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullRentedVehicleResponse(
                x.Id,
                x.Vehicle.ToFullVehicleResponse(mapper),
                x.Customer.ToCustomerResponse(mapper),
                x.StartRentDate,
                x.ExpectedEndRentDate,
                x.ExpectedAmount
            ));

}
