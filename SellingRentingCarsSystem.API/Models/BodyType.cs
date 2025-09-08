namespace SellingRentingCarsSystem.API.Models;

public class BodyType
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string TypeName { get; set; } = string.Empty;
    public int DoorCount { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; } =
    new List<Vehicle>();

}
