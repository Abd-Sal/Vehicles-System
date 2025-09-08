namespace SellingRentingCarsSystem.API.DTOs;

public record CombinationPowerTrainRequest(
    int HorsePower,
    decimal Torque,
    decimal CombinedRangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    float EngineSize,
    int Cylinders
);

