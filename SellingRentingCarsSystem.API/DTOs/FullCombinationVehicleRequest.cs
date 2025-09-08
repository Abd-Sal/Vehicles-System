namespace SellingRentingCarsSystem.API.DTOs;

public record FullCombinationVehicleRequest(
    string VIN,
    ModelRequest Model,
    string ExteriorColor,
    string InteriorColor,
    BodyTypeRequest BodyType,
    FuelTypeRequest FuelType,
    TransmissionTypeRequest TransmissionType,
    CombinationPowerTrainRequest PowerTrain,
    decimal VehiclePrice
) : IVehicleRequest;

