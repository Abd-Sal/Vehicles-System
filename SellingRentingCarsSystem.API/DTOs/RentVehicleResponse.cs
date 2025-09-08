namespace SellingRentingCarsSystem.API.DTOs;

public record RentVehicleResponse(
    string Id,
    string VehicleID,
    string CustomerID,
    int StartAtMile,
    int EndAtMile,
    DateTime StartRentDate,
    DateTime ExpectedEndRentDate,
    DateTime ActualEndRentDate,
    decimal ExpectedAmount,
    decimal? DamageAmount,
    string? DamageDescription,
    decimal Amount,
    bool PayLater,
    string? PaymentID
);

