namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateHybridPowerTrainRequest(
    int HorsePower,
    int Torque,
    float CombinationRangeMiles,
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

