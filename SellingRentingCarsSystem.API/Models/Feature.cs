namespace SellingRentingCarsSystem.API.Models;

public class Feature
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string FeatureName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public ICollection<VehicleFeature> VehicleFeatures { get; set; } =
        new List<VehicleFeature>();
}
