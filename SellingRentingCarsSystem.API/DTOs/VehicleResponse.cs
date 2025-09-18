namespace SellingRentingCarsSystem.API.DTOs;

public record VehicleResponse(
    string Id,
    string VIN,
    FullModelResponse Model,
    DateTime AddDate,
    int RangeMiles,
    string InteriorColor,
    string ExteriorColor,
    string VehicleStatus,
    BodyTypeResponse BodyType,
    TransmissionTypeResponse TransmissionType,
    int passengerCount,
    FullPowerTrainResponse PowerTrain,
    decimal VehiclePrice
);
