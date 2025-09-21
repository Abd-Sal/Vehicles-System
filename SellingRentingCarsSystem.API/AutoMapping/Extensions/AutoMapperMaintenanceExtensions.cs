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

}
