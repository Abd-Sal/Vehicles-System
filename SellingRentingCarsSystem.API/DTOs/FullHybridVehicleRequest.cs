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
    decimal VehiclePrice
) : IVehicleRequest;

