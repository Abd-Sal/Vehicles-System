namespace SellingRentingCarsSystem.API.Models;

public class FuelType
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string TypeName { get; set; } = string.Empty;

    public ICollection<PowerTrain> Vehicles { get; set; } =
        new List<PowerTrain>();

}
