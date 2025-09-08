namespace SellingRentingCarsSystem.API.Models;

public class VehicleTags
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string TagID { get; set; } = string.Empty;
    public string VehicleID { get; set; } = string.Empty;

    public Tag Tag { get; set; } = default!;
    public Vehicle Vehicle { get; set; } = default!;
}
