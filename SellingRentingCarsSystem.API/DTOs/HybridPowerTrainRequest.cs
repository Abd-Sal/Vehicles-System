namespace SellingRentingCarsSystem.API.DTOs;

public record HybridPowerTrainRequest(
    int HorsePower,
    decimal Torque,
    decimal CombinedRangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    float EngineSize,
    int Cylinders,
    decimal ElectricOnlyRangeMiles,
    string ChargePortID,
    int RangeMiles,
    decimal BatteryCapacityKWh,
    bool PlugInHybrid
);
