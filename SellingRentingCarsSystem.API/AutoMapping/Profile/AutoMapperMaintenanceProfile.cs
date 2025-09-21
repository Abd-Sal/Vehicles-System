namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperMaintenanceProfile : AutoMapper.Profile
{
    public AutoMapperMaintenanceProfile()
    {
        //Maintenance
        MaintenanceMapping();
        MaintenanceResponseMapping();
    }
    //Maintenance
    private void MaintenanceMapping()
        => CreateMap<MaintenanceRequest, Maintenance>().ReverseMap();
    private void MaintenanceResponseMapping()
        => CreateMap<Maintenance, MaintenanceResponse>().ReverseMap();
}
