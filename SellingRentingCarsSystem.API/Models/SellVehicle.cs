namespace SellingRentingCarsSystem.API.Models;

public class SellVehicle
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string VehicleID { get; set; } = string.Empty;
    public string CustomerID { get; set; } = string.Empty;
    public DateTime SellDate { get; set; }
    public string PaymentID { get; set; } = string.Empty;

    public Vehicle Vehicle { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
    public Payment Payment { get; set; } = default!;
}
