namespace SellingRentingCarsSystem.API.DTOs;

public record VehicleFullFeatureResponse(
    string Id,
    string VehicleID,
    FeatureResponse Feature,
    bool IsStandard
);



