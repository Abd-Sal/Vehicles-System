namespace SellingRentingCarsSystem.API.Models;

public class Customer
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string NID { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;

    public ICollection<SellVehicle> SellVehicle { get; set; } =
       new List<SellVehicle>();
    public ICollection<RentVehicle> RentVehicle { get; set; } =
        new List<RentVehicle>();
    public ICollection<Booking> Booking { get; set; } =
        new List<Booking>();
}
