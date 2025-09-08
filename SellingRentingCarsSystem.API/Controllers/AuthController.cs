namespace SellingRentingCarsSystem.API.Controllers;

[Route("auth")]
[ApiController]
public class AuthController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginRequest loginRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.AuthServices.GetTokenAsync(loginRequest.Email, loginRequest.Password, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAsync(
        [FromBody] RefreshTokenRequest refreshTokenRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.AuthServices.GetRefreshTokenAsync(refreshTokenRequest.Token, refreshTokenRequest.RefreshToken, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost("revoked-refresh-token")]
    public async Task<IActionResult> RevokeRefreshTokenAsync(
        [FromBody] RefreshTokenRequest refreshTokenRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.AuthServices.RevokeRefreshTokenAsync(refreshTokenRequest.Token, refreshTokenRequest.RefreshToken, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(
        [FromBody]ChangePasswordRequest changePasswordRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.AuthServices.ChangePassword(User.GetUserId()!, changePasswordRequest, cancellationToken);
        if (temp.IsSuccess) return NoContent();
        return temp.ToProblem();
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword(
        [FromBody]ForgetPasswordRequest forgetPasswordRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.AuthServices.SendResetPasswordToken(forgetPasswordRequest, cancellationToken);
        if (temp.IsSuccess) return NoContent();
        return temp.ToProblem();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(
        [FromBody]ResetPasswordRequest resetPasswordRequest,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.AuthServices.ResetPassword(resetPasswordRequest, cancellationToken);
        if (temp.IsSuccess) return NoContent();
        return temp.ToProblem();
    }

}