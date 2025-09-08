namespace SellingRentingCarsSystem.API.Models;

public class Tag
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string TagName { get; set; } = string.Empty;

    public ICollection<VehicleTags> VehileTags { get; set; } =
        new List<VehicleTags>();
}
