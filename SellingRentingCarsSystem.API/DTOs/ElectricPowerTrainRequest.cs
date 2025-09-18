namespace SellingRentingCarsSystem.API.DTOs;

public record ElectricPowerTrainRequest(
    int HorsePower,
    float Torque,
    float ElectricOnlyRangeMiles,
    string ChargePortID,
    float BatteryCapacityKWh
);

