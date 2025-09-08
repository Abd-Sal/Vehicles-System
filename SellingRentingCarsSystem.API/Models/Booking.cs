namespace SellingRentingCarsSystem.API.Models;

public class Booking
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string CustomerID { get; set; } = string.Empty;
    public string VehicleID { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal ExpectedAmount { get; set; }
    public bool Canceled { get; set; } = false;
    public bool Done { get; set; } = true;

    public Vehicle Vehicle { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
}
