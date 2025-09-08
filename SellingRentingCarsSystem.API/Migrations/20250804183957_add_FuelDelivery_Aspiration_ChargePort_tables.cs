using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class add_FuelDelivery_Aspiration_ChargePort_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aspirtaion",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "ChargePortType",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "FuelDelivery",
                table: "PowerTrains");

            migrationBuilder.AlterColumn<string>(
                name: "FuelTypeID",
                table: "PowerTrains",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspirationID",
                table: "PowerTrains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargePortID",
                table: "PowerTrains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelDeliveryID",
                table: "PowerTrains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aspirations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargePorts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelDeliveries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelDeliveries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIJPaldMC5gbqGlIIsVS4XoImsbip88MJgopDPzSpi+ATS94zZd6CX6SunupSvu4Tw==");

            migrationBuilder.CreateIndex(
                name: "IX_PowerTrains_AspirationID",
                table: "PowerTrains",
                column: "AspirationID");

            migrationBuilder.CreateIndex(
                name: "IX_PowerTrains_ChargePortID",
                table: "PowerTrains",
                column: "ChargePortID");

            migrationBuilder.CreateIndex(
                name: "IX_PowerTrains_FuelDeliveryID",
                table: "PowerTrains",
                column: "FuelDeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Aspirations_TypeName",
                table: "Aspirations",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargePorts_PortName",
                table: "ChargePorts",
                column: "PortName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelDeliveries_TypeName",
                table: "FuelDeliveries",
                column: "TypeName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerTrains_Aspirations_AspirationID",
                table: "PowerTrains",
                column: "AspirationID",
                principalTable: "Aspirations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerTrains_ChargePorts_ChargePortID",
                table: "PowerTrains",
                column: "ChargePortID",
                principalTable: "ChargePorts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerTrains_FuelDeliveries_FuelDeliveryID",
                table: "PowerTrains",
                column: "FuelDeliveryID",
                principalTable: "FuelDeliveries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PowerTrains_Aspirations_AspirationID",
                table: "PowerTrains");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerTrains_ChargePorts_ChargePortID",
                table: "PowerTrains");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerTrains_FuelDeliveries_FuelDeliveryID",
                table: "PowerTrains");

            migrationBuilder.DropTable(
                name: "Aspirations");

            migrationBuilder.DropTable(
                name: "ChargePorts");

            migrationBuilder.DropTable(
                name: "FuelDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_PowerTrains_AspirationID",
                table: "PowerTrains");

            migrationBuilder.DropIndex(
                name: "IX_PowerTrains_ChargePortID",
                table: "PowerTrains");

            migrationBuilder.DropIndex(
                name: "IX_PowerTrains_FuelDeliveryID",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "AspirationID",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "ChargePortID",
                table: "PowerTrains");

            migrationBuilder.DropColumn(
                name: "FuelDeliveryID",
                table: "PowerTrains");

            migrationBuilder.AlterColumn<string>(
                name: "FuelTypeID",
                table: "PowerTrains",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aspirtaion",
                table: "PowerTrains",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargePortType",
                table: "PowerTrains",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelDelivery",
                table: "PowerTrains",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPhvoGHgeIGHgYGhk1oCsUkqVEVuwgGvjSAKkMlJk4oklQ78Inbc3kqiqTCDBtB55g==");
        }
    }
}
