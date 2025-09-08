 namespace SellingRentingCarsSystem.API.Models;

public class Payment
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string PayType { get; set; } = PayTypes.Cash.ToString();
    public bool Receive { get; set; } = true;  //Receive : true,    send = false
    public decimal Amount { get; set; }
    public DateTime DateOfPay { get; set; } = DateTime.UtcNow;
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Maintenance? Maintenance { get; set; }
    public SellVehicle? SellVehicle { get; set; }
    public RentVehicle? RentVehicle { get; set; }
}
