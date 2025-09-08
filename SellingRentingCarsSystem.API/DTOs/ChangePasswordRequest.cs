namespace SellingRentingCarsSystem.API.DTOs;

public record ChangePasswordRequest(
    string OldPassword,
    string NewPassword
);
