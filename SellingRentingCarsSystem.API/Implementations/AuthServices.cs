namespace SellingRentingCarsSystem.API.Implementations;

public class AuthServices(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider,
    INotificationSender notificationSender,ILogger<AuthServices> logger) : IAuthServices
{
    private readonly UserManager<ApplicationUser> userManager = userManager;
    private readonly IJwtProvider jwtProvider = jwtProvider;
    private readonly INotificationSender notificationSender = notificationSender;
    private readonly ILogger<AuthServices> logger = logger;
    private readonly int _refreshTokenExpiryDays = 14;

    public async Task<Result<AuthResponse>> GetTokenAsync
        (string email, string password, CancellationToken cancellationToken = default)
    {
        ApplicationUser? user = await userManager.FindByEmailAsync(email);
        if (user is null)
            user = await userManager.FindByNameAsync(email);

        if (user is null)
            return Result.Failure<AuthResponse>(AuthErrors.UnauthenticateUserByName);

        if (!(await userManager.CheckPasswordAsync(user, password)))
            return Result.Failure<AuthResponse>(AuthErrors.UnauthenticateUserByName);

        var (token, expireIn) = jwtProvider.GenerateToken(user);

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await userManager.UpdateAsync(user);

        logger.LogInformation("user (ID:{Id}, Username:{username}) logged in", user.Id!, user.UserName);

        return Result.Success(new AuthResponse(user.Id, user.Email!, user.UserName!, token, expireIn, refreshToken, refreshTokenExpiration));
    }

    public async Task<Result<AuthResponse>> GetRefreshTokenAsync
        (string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = jwtProvider.ValidateToken(token);
        if (userId is null)
            return Result.Failure<AuthResponse>(new Error("NotAuthorized", "your are not authorized", StatusCodes.Status401Unauthorized));

        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return Result.Failure<AuthResponse>(new Error("NotAuthorized", "your are not authorized", StatusCodes.Status401Unauthorized));

        var userRefreshToken = user.RefreshTokens
            .SingleOrDefault(x => x.Token == refreshToken &&
            x.IsActive);
        if (userRefreshToken is null)
            return Result.Failure<AuthResponse>(new Error("NotAuthorized", "your are not authorized", StatusCodes.Status401Unauthorized));

        userRefreshToken.RevokedOn = DateTime.UtcNow;
        var newToken = jwtProvider.GenerateToken(user);

        var newRefreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            ExpiresOn = refreshTokenExpiration,
        });
        await userManager.UpdateAsync(user);

        return Result.Success(new AuthResponse
            (user.Id, user.Email!, user.UserName!, newToken.token, newToken.expiresIn, newRefreshToken, refreshTokenExpiration));
    }

    public async Task<Result<bool>> RevokeRefreshTokenAsync
        (string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = jwtProvider.ValidateToken(token);
        if (userId is null)
            return Result.Failure<bool>(new Error("NotAuthorized", "your are not authorized", StatusCodes.Status401Unauthorized));

        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return Result.Failure<bool>(new Error("NotAuthorized", "your are not authorized", StatusCodes.Status401Unauthorized));

        var userRefreshToken = user.RefreshTokens
            .SingleOrDefault(x => x.Token == refreshToken &&
            x.IsActive);
        if (userRefreshToken is null)
            return Result.Failure<bool>(new Error("NotAuthorized", "your are not authorized", StatusCodes.Status401Unauthorized));

        userRefreshToken.RevokedOn = DateTime.UtcNow;
        await userManager.UpdateAsync(user);
        return Result.Success(true);
    }

    public async Task<Result> ChangePassword
        (string userID, ChangePasswordRequest changePasswordRequest, CancellationToken cancellationToken = default)
    {
        if (await userManager.FindByIdAsync(userID) is not { } user)
            return Result.Failure(AuthErrors.NotFoundUser);

        var changePassword = await userManager.ChangePasswordAsync(user, changePasswordRequest.OldPassword, changePasswordRequest.NewPassword);
        if(changePassword is null)
            return Result.Failure(AuthErrors.UnauthenticateUserByName);

        logger.LogInformation("user (ID:{Id}, Username:{username}) Change His Password", user.Id!, user.UserName);

        return Result.Success();
    }

    public async Task<Result> SendResetPasswordToken
        (ForgetPasswordRequest forgetPasswordRequest, CancellationToken cancellationToken = default)
    {
        if (await userManager.FindByEmailAsync(forgetPasswordRequest.Email) is not { } user)
            return Result.Success();

        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        notificationSender
            .SendEmailAsync(forgetPasswordRequest.Email, ConstantStrings.SubjecyForResetPassword, ConstantStrings.BodyForResetPassword(code));

        logger.LogInformation("user (ID:{Id}, Username:{username}) Ask for reset password code", user.Id!, user.UserName);

        return Result.Success();
    }

    public async Task<Result> ResetPassword
        (ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken = default)
    {
        if (await userManager.FindByEmailAsync(resetPasswordRequest.Email) is not { } user)
            return Result.Failure(AuthErrors.InvalidCode);

        IdentityResult? result = null;
        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPasswordRequest.Code));
            result = await userManager.ResetPasswordAsync(user, code, resetPasswordRequest.NewPassword);
        }
        catch (FormatException)
        {
            result = IdentityResult.Failed(userManager.ErrorDescriber.InvalidToken());

        }

        if (result.Succeeded)
        {
            logger.LogInformation("user (ID:{Id}, Username:{username}) reset his password", user.Id!, user.UserName);
            return Result.Success();
        }

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status401Unauthorized));
    }

    private static string GenerateRefreshToken()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

}
