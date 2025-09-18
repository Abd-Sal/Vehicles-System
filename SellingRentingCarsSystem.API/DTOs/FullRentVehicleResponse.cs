namespace SellingRentingCarsSystem.API.DTOs;

public record FullRentVehicleResponse(
    string Id,
    VehicleResponse Vehicle,
    CustomerResponse Customer,
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
    PaymentResponse Payment
);

