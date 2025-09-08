namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateElectricPowerTrainRequest(
    int HorsePower,
    decimal Torque,
    decimal ElectricRangeMiles,
    string ChargePortTypeID,
    int RangeMiles,
    decimal BatteryCapacityKWh
);

