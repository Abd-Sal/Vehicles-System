using Microsoft.AspNetCore.Identity;
using SellingRentingCarsSystem.API.Abstractions.Consts;

namespace SellingRentingCarsSystem.API.Data.Configurations;

public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .OwnsMany(x => x.RefreshTokens)
            .ToTable("RefreshTokens")
            .WithOwner()
            .HasForeignKey("UserId");

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        builder.HasData([            new ApplicationUser{    //Admin
                Id = DefaultUsers.AdminID,
                UserName = DefaultUsers.AdminUsername,
                Email = DefaultUsers.AdminEmail,
                NormalizedUserName = DefaultUsers.AdminUsername.ToUpper(),
                NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
                SecurityStamp = DefaultUsers.AdminSecurityStamp,
                ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null!, DefaultUsers.AdminPassword)
            }]);

    }
}
