namespace SellingRentingCarsSystem.API.Models;

public class VehicleFeature
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string VehicleID { get; set; } = string.Empty;
    public string FeatureID { get; set; } = string.Empty;
    public bool IsStandard { get; set; }

    public Vehicle Vehicle{ get; set; } = default!;
    public Feature Feature { get; set; } = default!;
}
