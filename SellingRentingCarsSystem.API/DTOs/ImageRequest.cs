namespace SellingRentingCarsSystem.API.DTOs;

public record ImageRequest(
    bool IsPrimary,
    string? Caption,
    IFormFile Image
);