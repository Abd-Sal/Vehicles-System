namespace SellingRentingCarsSystem.API.DTOs;

public record HybridPowerTrainRequest(
    int HorsePower,
    float Torque,
    float CombinedRangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    float EngineSize,
    int Cylinders,
    float ElectricOnlyRangeMiles,
    string ChargePortID,
    float BatteryCapacityKWh,
    bool PlugInHybrid
);
