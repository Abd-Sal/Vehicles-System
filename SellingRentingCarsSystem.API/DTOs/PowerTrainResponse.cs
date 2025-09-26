namespace SellingRentingCarsSystem.API.DTOs;

public record PowerTrainResponse(
    string Id,
    string PowerTrainType,
    int HorsePower,
    int Torque,
    float? CombinedRangeMiles = null,
    float? ElectricOnlyRangeMiles = null,
    string? ChargePortID = null,
    float? BatteryCapacityKWh = null,
    string? FuelDeliveryID = null,
    string? FuelTypeID = null,
    string? AspirationID = null,
    string? TransmissionTypeID = null,
    float? EngineSize = null,
    int? Cylinders = null
);


