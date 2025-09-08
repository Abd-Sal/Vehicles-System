namespace SellingRentingCarsSystem.API.DTOs;

public record VehicleFeatureResponse(
    string Id,
    string VehicleID,
    string FeatureID,
    bool IsStandard
);


