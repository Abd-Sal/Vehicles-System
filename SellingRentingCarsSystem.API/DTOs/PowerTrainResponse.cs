namespace SellingRentingCarsSystem.API.DTOs;

public record PowerTrainResponse(
    string Id,
    string PowerTrainType,
    int HorsePower,
    decimal Torque,
    decimal? CombinedRangeMiles = null,
    decimal? ElectricOnlyRangeMiles = null,
    string? ChargePortID = null,
    decimal? BatteryCapacityKWh = null,
    string? FuelDeliveryID = null,
    string? FuelTypeID = null,
    string? AspirationID = null,
    float? EngineSize = null,
    int? Cylinders = null
);

