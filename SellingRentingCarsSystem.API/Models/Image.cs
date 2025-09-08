namespace SellingRentingCarsSystem.API.Models;

public class Image
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string VehicleID { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = true;
    public string? Caption { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public int SizeInBytes { get; set; }

    public Vehicle Vehicle { get; set; } = default!;
}

