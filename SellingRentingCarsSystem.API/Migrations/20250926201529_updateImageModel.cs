using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class updateImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBBYN6gGIPKykBe///pNHJSMNckdzVuAjekyWW7u/EZ2ghnltC84g3q7kSPzyHvzPA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH8ihOxT4VyiVJDJxdrBZwJ8Au5BsabRk+vz95uBSLEsftvmDkQn61mLRr7IRGojqg==");
        }
    }
}
