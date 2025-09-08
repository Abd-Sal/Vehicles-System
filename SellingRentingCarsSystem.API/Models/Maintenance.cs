namespace SellingRentingCarsSystem.API.Models;

public class Maintenance
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string VehicleID { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PaymentID { get; set; } = string.Empty;
    public DateTime DoneAt { get; set; } = DateTime.UtcNow;

    public Vehicle Vehicle { get; set; } = default!;
    public Payment Payment { get; set; } = default!;
}