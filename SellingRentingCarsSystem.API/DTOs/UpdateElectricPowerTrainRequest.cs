namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateElectricPowerTrainRequest(
    int HorsePower,
    float Torque,
    float ElectricOnlyRangeMiles,
    string ChargePortID,
    float BatteryCapacityKWh
);

