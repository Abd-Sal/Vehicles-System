namespace SellingRentingCarsSystem.API.Interfaces;

public interface IAuthServices
{
    Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result<bool>> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result> ChangePassword(string userID, ChangePasswordRequest changePasswordRequest, CancellationToken cancellationToken = default);
    Task<Result> SendResetPasswordToken(ForgetPasswordRequest forgetPasswordRequest, CancellationToken cancellationToken = default);
    Task<Result> ResetPassword(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken = default);
}
