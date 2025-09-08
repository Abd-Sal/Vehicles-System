namespace SellingRentingCarsSystem.API.DTOs;

public record StopRentVehicleRequest(
    string Id,
    string VehicleID,
    string CustomerID,
    int EndMile,
    DateTime ActualEndRentDate,
    decimal? DamageAmount,
    string? DamageDescription,
    decimal Amount,
    PaymentRequest? Payment
);

