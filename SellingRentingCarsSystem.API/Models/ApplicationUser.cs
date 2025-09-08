namespace SellingRentingCarsSystem.API.Models;

public class ApplicationUser : IdentityUser
{
    public List<RefreshToken> RefreshTokens { get; set; } = [];
}
