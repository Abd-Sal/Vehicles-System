using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class add_fuelType_for_powerTrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_FuelTypeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelTypeID",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "FuelTypeID",
                table: "PowerTrains",
                type: "nvarchar(450)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPhvoGHgeIGHgYGhk1oCsUkqVEVuwgGvjSAKkMlJk4oklQ78Inbc3kqiqTCDBtB55g==");

            migrationBuilder.CreateIndex(
                name: "IX_PowerTrains_FuelTypeID",
                table: "PowerTrains",
                column: "FuelTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerTrains_FuelTypes_FuelTypeID",
                table: "PowerTrains",
                column: "FuelTypeID",
                principalTable: "FuelTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PowerTrains_FuelTypes_FuelTypeID",
                table: "PowerTrains");

            migrationBuilder.DropIndex(
                name: "IX_PowerTrains_FuelTypeID",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "FuelTypeID",
                table: "PowerTrains");

            migrationBuilder.AddColumn<string>(
                name: "FuelTypeID",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH1S95fPtkbS7hblzIjuOVxCx+gCV1rO1aURKBM4ioz0h2pZ8KtB3KMdh3TrLuGgwA==");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeID",
                table: "Vehicles",
                column: "FuelTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeID",
                table: "Vehicles",
                column: "FuelTypeID",
                principalTable: "FuelTypes",
                principalColumn: "Id");
        }
    }
}
