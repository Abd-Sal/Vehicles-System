namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperVehicleExtensions
{
    //Vehicle
    public static VehicleResponse ToFullVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => new VehicleResponse(
                vehicle.Id, vehicle.VIN, vehicle.Model.ToFullModel(mapper),
                vehicle.AddDate, vehicle.RangeMiles, vehicle.InteriorColor, vehicle.ExteriorColor,
                vehicle.VehicleStatus, vehicle.BodyType.ToBodyTypeResponse(mapper),
                vehicle.TransmissionType.ToTransmissionTypeResponse(mapper), vehicle.PassengerCount,
                vehicle.PowerTrain.ToFullPowerTrain(mapper), vehicle.VehiclePrice
            );
    public static Vehicle ToVehicle(this VehicleRequest vehicleRequest, IMapper mapper)
        => mapper.Map<Vehicle>(vehicleRequest);
    public static BriefVehicleResponse ToBriefVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => mapper.Map<BriefVehicleResponse>(vehicle);
    public static List<BriefVehicleResponse> ToBriefVehicleResponses(this IEnumerable<Vehicle> vehicles, IMapper mapper)
        => mapper.Map<List<BriefVehicleResponse>>(vehicles);
    public static IQueryable<VehicleResponse> ToVehicleResponse(this IQueryable<Vehicle> vehicles, IMapper mapper)
        => vehicles.AsNoTracking()
            .Include(x => x.BodyType)
            .Include(x => x.Model)
            .Include(x => x.Model.Make)
            .Include(x => x.TransmissionType)
            .Include(x => x.PowerTrain)
            .Include(x => x.PowerTrain.ChargePort)
            .Include(x => x.PowerTrain.FuelDelivery)
            .Include(x => x.PowerTrain.FuleType)
            .Include(x => x.PowerTrain.Aspiration)
        .Select(x => new VehicleResponse(
            x.Id, x.VIN, x.Model.ToFullModel(mapper), x.AddDate,
            x.RangeMiles, x.InteriorColor, x.ExteriorColor, x.VehicleStatus, x.BodyType.ToBodyTypeResponse(mapper),
            x.TransmissionType.ToTransmissionTypeResponse(mapper), x.PassengerCount, x.PowerTrain.ToFullPowerTrain(mapper),
            x.VehiclePrice
        ));
    public static VehicleStatusResponse ToVehicleStatusResponse(this Vehicle vehicle)
        => new VehicleStatusResponse(vehicle.VehicleStatus);

}
