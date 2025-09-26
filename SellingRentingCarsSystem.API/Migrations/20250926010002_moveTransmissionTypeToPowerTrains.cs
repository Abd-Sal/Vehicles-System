using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class moveTransmissionTypeToPowerTrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_TransmissionTypes_TransmissionTypeID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TransmissionTypeID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TransmissionTypeID",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "TransmissionTypeID",
                table: "PowerTrains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH8ihOxT4VyiVJDJxdrBZwJ8Au5BsabRk+vz95uBSLEsftvmDkQn61mLRr7IRGojqg==");

            migrationBuilder.CreateIndex(
                name: "IX_PowerTrains_TransmissionTypeID",
                table: "PowerTrains",
                column: "TransmissionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerTrains_TransmissionTypes_TransmissionTypeID",
                table: "PowerTrains",
                column: "TransmissionTypeID",
                principalTable: "TransmissionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PowerTrains_TransmissionTypes_TransmissionTypeID",
                table: "PowerTrains");

            migrationBuilder.DropIndex(
                name: "IX_PowerTrains_TransmissionTypeID",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "TransmissionTypeID",
                table: "PowerTrains");

            migrationBuilder.AddColumn<string>(
                name: "TransmissionTypeID",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELOwj8scUMm5lRyoXHjSu2ShhU1Y10SIsoSEnrxPPIXu94k38J5eqRckBOBBX3V+Bw==");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionTypeID",
                table: "Vehicles",
                column: "TransmissionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_TransmissionTypes_TransmissionTypeID",
                table: "Vehicles",
                column: "TransmissionTypeID",
                principalTable: "TransmissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
