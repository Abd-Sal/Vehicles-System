namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateCombinationPowerTrainRequest(
    int HorsePower,
    int Torque,
    float CombinedRangeMiles,
    int RangeMiles,
    string FuelDeliveryID,
    string FuelTypeID,
    string AspirationID,
    string TransmissionTypeID,
    float EngineSize,
    int Cylinders
);

