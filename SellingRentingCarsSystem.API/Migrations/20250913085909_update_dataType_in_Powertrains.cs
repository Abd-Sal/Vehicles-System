using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class update_dataType_in_Powertrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Torque",
                table: "PowerTrains",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "ElectricOnlyRangeMiles",
                table: "PowerTrains",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CombinedRangeMiles",
                table: "PowerTrains",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "BatteryCapacityKWh",
                table: "PowerTrains",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELOwj8scUMm5lRyoXHjSu2ShhU1Y10SIsoSEnrxPPIXu94k38J5eqRckBOBBX3V+Bw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Torque",
                table: "PowerTrains",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectricOnlyRangeMiles",
                table: "PowerTrains",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CombinedRangeMiles",
                table: "PowerTrains",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BatteryCapacityKWh",
                table: "PowerTrains",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA1pvzIjnBUTr57gNuymUnmM26JUFAf+TbP/tM6gzsB6F+/PGjxxRUBViHEjerQqdA==");
        }
    }
}
