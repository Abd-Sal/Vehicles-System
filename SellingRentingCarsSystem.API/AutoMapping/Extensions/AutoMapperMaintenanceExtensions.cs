namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperMaintenanceExtensions
{
    //Maintenance
    public static Maintenance ToMaintenance(this MaintenanceRequest maintenanceRequest, IMapper mapper)
        => mapper.Map<Maintenance>(maintenanceRequest);
    public static MaintenanceResponse ToMaintenanceResponse(this Maintenance maintenance, IMapper mapper)
        => mapper.Map<MaintenanceResponse>(maintenance);
    public static List<MaintenanceResponse> ToMaintenanceResponses(this IEnumerable<Maintenance> maintenances, IMapper mapper)
        => mapper.Map<List<MaintenanceResponse>>(maintenances);
    public static IQueryable<FullMaintenanceResponse> ToFullMaintenanceResponses(this IQueryable<Maintenance> maintenances, IMapper mapper)
        => maintenances.AsNoTracking()
            .Include(x => x.Payment)
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
            .Include(x => x.Vehicle.PowerTrain.TransmissionType)
        .Select(x => new FullMaintenanceResponse(
            x.Id,
            x.Vehicle.ToFullVehicleResponse(mapper),
            x.Title,
            x.Description,
            x.Payment.ToPaymentResponse(mapper),
            x.DoneAt
        ));


}
