namespace SellingRentingCarsSystem.API.DTOs;

public record ResetPasswordRequest(
    string Email,
    string Code,
    string NewPassword
);