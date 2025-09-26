namespace SellingRentingCarsSystem.API.Models;

public class PowerTrain
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string PowerTrainType { get; set; } = string.Empty;
    public int HorsePower { get; set; }
    public int Torque { get; set; }
    public float? CombinedRangeMiles { get; set; }
    public float? ElectricOnlyRangeMiles { get; set; }
    public string? ChargePortID { get; set; }
    public float? BatteryCapacityKWh { get; set; }
    public string? FuelDeliveryID { get; set; }
    public string? FuelTypeID { get; set; }
    public string? AspirationID { get; set; }
    public string? TransmissionTypeID { get; set; }
    public float? EngineSize { get; set; }
    public int? Cylinders { get; set; }
    public string HashCode { get; set; } = string.Empty;

    public ICollection<Vehicle> Vehicles { get; set; } =
        new List<Vehicle>();
    public TransmissionType? TransmissionType { get; set; }
    public FuelType? FuleType { get; set; }
    public FuelDelivery? FuelDelivery { get; set; }
    public Aspiration? Aspiration { get; set; }
    public ChargePort? ChargePort { get; set; }
}
