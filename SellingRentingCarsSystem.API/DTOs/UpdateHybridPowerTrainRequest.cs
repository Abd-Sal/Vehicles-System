namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateHybridPowerTrainRequest(
    int HorsePower,
    decimal Torque,
    decimal CombinationRangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    float EngineSize,
    int Cylinders,
    decimal ElectricRangeMiles,
    string ChargePortTypeID,
    int RangeMiles,
    decimal BatteryCapacityKWh,
    bool PlugInHybrid
);

