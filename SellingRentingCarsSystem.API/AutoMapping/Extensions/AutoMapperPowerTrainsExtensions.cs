namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperPowerTrainsExtensions
{ 
    //PowerTrain
    public static FullPowerTrainResponse ToFullPowerTrain(this PowerTrain powerTrain, IMapper mapper)
        => new FullPowerTrainResponse(
            powerTrain.Id, powerTrain.PowerTrainType, powerTrain.HorsePower,
            powerTrain.Torque, powerTrain.CombinedRangeMiles, powerTrain.ElectricOnlyRangeMiles,
            powerTrain.ChargePort != null ? powerTrain.ChargePort.ToChargePortResponse(mapper) : null,
            powerTrain.BatteryCapacityKWh,
            powerTrain.FuelDelivery != null ? powerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
            powerTrain.FuleType != null ? powerTrain.FuleType.ToFuelTypeResponse(mapper) : null,
            powerTrain.Aspiration != null ? powerTrain.Aspiration.ToAspirationResponse(mapper) : null,
            powerTrain.TransmissionType != null ? powerTrain.TransmissionType.ToTransmissionTypeResponse(mapper) : null,
            powerTrain.EngineSize, powerTrain.Cylinders);
    public static PowerTrain ToPowerTrain(this CombinationPowerTrainRequest combinationPowerTrainRequest, IMapper mapper)
        => mapper.Map<PowerTrain>(combinationPowerTrainRequest);
    public static PowerTrain ToPowerTrain(this ElectricPowerTrainRequest electricPowerTrainRequest, IMapper mapper)
        => mapper.Map<PowerTrain>(electricPowerTrainRequest);
    public static PowerTrain ToPowerTrain(this HybridPowerTrainRequest hybridPowerTrainRequest, IMapper mapper)
        => mapper.Map<PowerTrain>(hybridPowerTrainRequest);
    public static PowerTrainResponse ToPowerTrainResponse(this PowerTrain powerTrain, IMapper mapper)
        => mapper.Map<PowerTrainResponse>(powerTrain);
    public static List<PowerTrainResponse> ToPowerTrainResponses(this IEnumerable<PowerTrain> powerTrains, IMapper mapper)
        => mapper.Map<List<PowerTrainResponse>>(powerTrains);
    public static IQueryable<FullPowerTrainResponse> ToFullPowerTrain(this IQueryable<PowerTrain> powerTrains, IMapper mapper)
        => powerTrains.AsNoTracking()
            .Include(x => x.ChargePort)
            .Include(x => x.FuleType)
            .Include(x => x.FuelDelivery)
            .Include(x => x.Aspiration)
            .Include(x => x.TransmissionType)
            .Select(x => x.ToFullPowerTrain(mapper));

}
