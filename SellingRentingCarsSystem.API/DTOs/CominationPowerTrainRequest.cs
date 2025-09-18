namespace SellingRentingCarsSystem.API.DTOs;

public record CombinationPowerTrainRequest(
    int HorsePower,
    float Torque,
    float CombinedRangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    float EngineSize,
    int Cylinders
);

