namespace SellingRentingCarsSystem.API.DTOs;

public record VehicleRequest(
    string VIN,
    string ModelID,
    string ExteriorColor,
    string InteriorColor,
    string BodyTypeID,
    string TransmissionTypeID,
    string PowerTrainID,
    int RangeMiles,
    decimal VehiclePrice
);
