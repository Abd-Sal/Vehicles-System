namespace SellingRentingCarsSystem.API.Models;

public class RentVehicle
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string VehicleID { get; set; } = string.Empty;
    public string CustomerID { get; set; } = string.Empty;
    public int StartAtMile { get; set; }
    public int? EndAtMile { get; set; }
    public DateTime StartRentDate { get; set; } = DateTime.UtcNow;
    public DateTime ExpectedEndRentDate { get; set; }
    public DateTime? ActualEndRentDate { get; set; }
    public decimal ExpectedAmount { get; set; }
    public decimal? DamageAmount { get; set; }
    public string? DamageDescription { get; set; } = string.Empty;
    public decimal? Amount { get; set; }
    public bool PayLater { get; set; } = false;
    public string? PaymentID { get; set; }


    public Vehicle Vehicle { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
    public Payment? Payment { get; set; }
}
