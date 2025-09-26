namespace SellingRentingCarsSystem.API.DTOs;

public record BriefVehicleResponse(
    string Id,
    string VIN,
    string ModelID,
    DateTime AddDate,
    int RangeMiles,
    string ExteriorColor,
    string InteriorColor,
    string VehicleStatus,
    string BodyTypeID,
    int PassengerCount,
    string PowerTrainID,
    decimal VehiclePrice
);
