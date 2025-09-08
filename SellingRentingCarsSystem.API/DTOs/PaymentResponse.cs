namespace SellingRentingCarsSystem.API.DTOs;

public record PaymentResponse(
    string Id,
    string PayType,
    decimal Amount,
    DateTime DateOfPay,
    string? Title,
    string? Description
);
