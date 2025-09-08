namespace SellingRentingCarsSystem.API.DTOs;

public record ElectricPowerTrainRequest(
    int HorsePower,
    decimal Torque,
    decimal ElectricRangeMiles,
    string ChargePortTypeID,
    int RangeMiles,
    decimal BatteryCapacityKWh
);

