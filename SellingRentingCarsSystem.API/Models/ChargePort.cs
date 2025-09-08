namespace SellingRentingCarsSystem.API.Models;

public class ChargePort
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string PortName { get; set; } = string.Empty;

    public ICollection<PowerTrain> PowerTrains { get; set; } =
        new List<PowerTrain>();
}