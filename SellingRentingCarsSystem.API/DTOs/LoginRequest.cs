namespace SellingRentingCarsSystem.API.DTOs;

public record LoginRequest(
    string Email,
    string Password
);