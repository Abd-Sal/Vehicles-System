namespace SellingRentingCarsSystem.API.DTOs;

public record FullElectricVehicleRequest(
    string VIN,
    ModelRequest Model,
    string ExteriorColor,
    string InteriorColor,
    BodyTypeRequest BodyType,
    TransmissionTypeRequest TransmissionType,
    ElectricPowerTrainRequest PowerTrain,
    int RangeMiles,
    int PassengerCount,
    decimal VehiclePrice
) : IVehicleRequest;

