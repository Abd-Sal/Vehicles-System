namespace SellingRentingCarsSystem.API.DTOs;

public record BriefVehicleResponse(
    string Id,
    string VIN,
    string ModelID,
    DateTime AddDate,
    string ExteriorColor,
    string InteriorColor,
    string VehicleStatus,
    string BodyTypeID,
    string? FuelTypeID,
    string TransmissionTypeID,
    int PassengerCount,
    string PowerTrainID,
    decimal VehiclePrice
);
