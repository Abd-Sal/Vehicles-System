namespace SellingRentingCarsSystem.API.DTOs;

public record AuthResponse(
    string Id,
    string Email,
    string Username,
    string Token,
    int ExpireIn,
    string RefreshToken,
    DateTime RefreshTokenExpiration
);
