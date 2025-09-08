namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateCombinationPowerTrainRequest(
    int HorsePower,
    decimal Torque,
    decimal CombinedRangeMiles,
    int RangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    float EngineSize,
    int Cylinders
);

