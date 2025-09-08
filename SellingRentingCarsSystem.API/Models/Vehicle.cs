namespace SellingRentingCarsSystem.API.Models;

public class Vehicle
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string VIN { get; set; } = string.Empty;
    public string ModelID { get; set; } = string.Empty;
    public DateTime AddDate { get; set; } = DateTime.UtcNow;
    public int RangeMiles { get; set; }
    public string ExteriorColor { get; set; } = string.Empty;
    public string InteriorColor { get; set; } = string.Empty;
    public string VehicleStatus { get; set; } = VehiclesStatus.available.ToString();
    public string BodyTypeID { get; set; } = string.Empty;
    public string TransmissionTypeID { get; set; } = string.Empty;
    public int PassengerCount { get; set; } = 5;
    public string PowerTrainID { get; set; } = string.Empty;
    public decimal VehiclePrice { get; set; }

    public BodyType BodyType { get; set; } = default!;
    public Model Model { get; set; } = default!;
    public TransmissionType TransmissionType { get; set; } = default!;
    public PowerTrain PowerTrain { get; set; } = default!;
    public ICollection<VehicleFeature> VehicleFeatures { get; set; } =
        new List<VehicleFeature>();
    public ICollection<Image> Images { get; set; } =
        new List<Image>();
    public ICollection<VehicleTags> VehileTags { get; set; } =
        new List<VehicleTags>();
    public SellVehicle? SellVehicle { get; set; }
    public ICollection<RentVehicle> RentVehicles { get; set; } = 
        new List<RentVehicle>();
    public ICollection<Booking> Booking { get; set; } =
        new List<Booking>();
    public ICollection<Maintenance> Maintenances { get; set; } =
        new List<Maintenance>();
}
