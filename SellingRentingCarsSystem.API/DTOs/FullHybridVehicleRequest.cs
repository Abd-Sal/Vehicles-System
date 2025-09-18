namespace SellingRentingCarsSystem.API.DTOs;

public record FullHybridVehicleRequest(
    string VIN,
    ModelRequest Model,
    string ExteriorColor,
    string InteriorColor,
    BodyTypeRequest BodyType,
    FuelTypeRequest FuelType,
    TransmissionTypeRequest TransmissionType,
    HybridPowerTrainRequest PowerTrain,
    int RangeMiles,
    int PassengerCount,
    decimal VehiclePrice
) : IVehicleRequest;

