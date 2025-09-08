namespace SellingRentingCarsSystem.API.DTOs;

public record PaymentRequest(
    string PayType,
    decimal Amount,
    string? Title,
    string? Description
);

