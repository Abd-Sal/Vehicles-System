namespace SellingRentingCarsSystem.API.DTOs;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken
);