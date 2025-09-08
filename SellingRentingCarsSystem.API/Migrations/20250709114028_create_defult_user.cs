using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class create_defult_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a0d8d62-fad1-4803-b768-5d22153fd11c", 0, "f6c081f7-b116-45b5-af15-4c4f86ced16f", "ApplicationUser", "admin.01@teml.net", true, false, null, "ADMIN.01@TEML.NET", "ADMIN", "AQAAAAIAAYagAAAAEMytzsSwwcsvGrjjguL1xBYfe4UfoglvHjfcV8XyrSmU+dOxREQJI0wVHnCr7UflIQ==", null, false, "A180686382BE42DDA62A4DAE3CA4C96D", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c");
        }
    }
}
