namespace SellingRentingCarsSystem.API.DTOs;

public record FullPowerTrainResponse(
    string Id,
    string PowerTrainType,
    int HorsePower,
    int Torque,
    float? CombinedRangeMiles = null,
    float? ElectricOnlyRangeMiles = null,
    ChargePortResponse? ChargePort = null,
    float? BatteryCapacityKWh = null,
    FuelDeliveryResponse? FuelDelivery = null,
    FuelTypeResponse? FuelType = null,
    AspirationResponse? Aspiration = null,
    float? EngineSize = null,
    int? Cylinders = null
);


