namespace SellingRentingCarsSystem.API.DTOs;

public record ImageResponse(
    string Id,
    string VehicleID,
    string ImageName,
    bool IsPrimary,
    string Caption,
    int SizeInBytes
);
