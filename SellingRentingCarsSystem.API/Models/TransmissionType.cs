namespace SellingRentingCarsSystem.API.Models;

public class TransmissionType
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string TypeName { get; set; } = string.Empty;

    public ICollection<PowerTrain> PowerTrains { get; set; } = [];
}
