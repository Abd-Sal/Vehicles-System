namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperVehicleExtensions
{
    //Vehicle
    public static VehicleResponse ToFullVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => new VehicleResponse(
                vehicle.Id, vehicle.VIN, vehicle.Model.ToFullModel(mapper),
                vehicle.AddDate, vehicle.RangeMiles, vehicle.InteriorColor, vehicle.ExteriorColor,
                vehicle.VehicleStatus, vehicle.BodyType.ToBodyTypeResponse(mapper),
                vehicle.PassengerCount,
                vehicle.PowerTrain.ToFullPowerTrain(mapper),
                vehicle.Images.Select(x => x.ToImageResponse(mapper)).ToArray(),
                vehicle.VehiclePrice
            );
    public static Vehicle ToVehicle(this VehicleRequest vehicleRequest, IMapper mapper)
        => mapper.Map<Vehicle>(vehicleRequest);
    public static BriefVehicleResponse ToBriefVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => mapper.Map<BriefVehicleResponse>(vehicle);
    public static List<BriefVehicleResponse> ToBriefVehicleResponses(this IEnumerable<Vehicle> vehicles, IMapper mapper)
        => mapper.Map<List<BriefVehicleResponse>>(vehicles);
    public static IQueryable<VehicleResponse> ToVehicleResponse(this IQueryable<Vehicle> vehicles, IMapper mapper)
        => vehicles.AsNoTracking()
            .Include(x => x.Images)
            .Include(x => x.BodyType)
            .Include(x => x.Model)
            .Include(x => x.Model.Make)
            .Include(x => x.PowerTrain)
            .Include(x => x.PowerTrain.ChargePort)
            .Include(x => x.PowerTrain.FuelDelivery)
            .Include(x => x.PowerTrain.FuleType)
            .Include(x => x.PowerTrain.Aspiration)
            .Include(x => x.PowerTrain.TransmissionType)
        .Select(x => x.ToFullVehicleResponse(mapper));
    public static VehicleStatusResponse ToVehicleStatusResponse(this Vehicle vehicle)
        => new VehicleStatusResponse(vehicle.VehicleStatus);

}
