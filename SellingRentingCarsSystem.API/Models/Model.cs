namespace SellingRentingCarsSystem.API.Models;

public class Model
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string MakeID { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int ProductionYear { get; set; }

    public Make Make { get; set; } = default!;
    public ICollection<Vehicle> Vehicles { get; set; } =
        new List<Vehicle>();
}
