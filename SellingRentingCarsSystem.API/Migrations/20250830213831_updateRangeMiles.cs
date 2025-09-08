using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellingRentingCarsSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class updateRangeMiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RangeMiles",
                table: "PowerTrains");

            migrationBuilder.AddColumn<int>(
                name: "RangeMiles",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA1pvzIjnBUTr57gNuymUnmM26JUFAf+TbP/tM6gzsB6F+/PGjxxRUBViHEjerQqdA==");

            migrationBuilder.InsertData(
                table: "Aspirations",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { "0198c34a-8ba0-7089-a560-47aa3acdb58a", "Forced Induction" },
                    { "0198c34a-8ba0-7089-a560-47abace73521", "Naturally Aspirated" }
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "Id", "DoorCount", "TypeName" },
                values: new object[,]
                {
                    { "0198c34a-8ba0-7089-a560-47916546c9a9", 2, "Convertible" },
                    { "0198c34a-8ba0-7089-a560-479224bb6185", 4, "Convertible" },
                    { "0198c34a-8ba0-7089-a560-47938977ae7c", 2, "Coupe" },
                    { "0198c34a-8ba0-7089-a560-479495a61551", 4, "Crossover" },
                    { "0198c34a-8ba0-7089-a560-4795267320fb", 2, "Hatchback" },
                    { "0198c34a-8ba0-7089-a560-4796ba3aa031", 4, "Hatchback" },
                    { "0198c34a-8ba0-7089-a560-479737348d88", 3, "Minivan" },
                    { "0198c34a-8ba0-7089-a560-4798ee6d43e4", 4, "Minivan" },
                    { "0198c34a-8ba0-7089-a560-4799f3cd22ef", 2, "Pickup Truck" },
                    { "0198c34a-8ba0-7089-a560-479ae1fe64af", 4, "Pickup Truck" },
                    { "0198c34a-8ba0-7089-a560-479ba551f176", 4, "Sedan" },
                    { "0198c34a-8ba0-7089-a560-479cc5b9e724", 4, "SUV" },
                    { "0198c34a-8ba0-7089-a560-479df0e1384b", 4, "Wagon" }
                });

            migrationBuilder.InsertData(
                table: "ChargePorts",
                columns: new[] { "Id", "PortName" },
                values: new object[,]
                {
                    { "0198c34a-8ba0-7089-a560-479ec048048e", "CCS (Combined Charging System)" },
                    { "0198c34a-8ba0-7089-a560-479fd7feef0b", "CHAdeMO" },
                    { "0198c34a-8ba0-7089-a560-47a09b2b2ce9", "GB/T" },
                    { "0198c34a-8ba0-7089-a560-47a1e5ec96c5", "J1772" },
                    { "0198c34a-8ba0-7089-a560-47a2c8a011dd", "Mennekes - AC Charging" },
                    { "0198c34a-8ba0-7089-a560-47a3a8bca916", "Tesla Connector NACS" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Category", "FeatureName" },
                values: new object[,]
                {
                    { "0198c37d-3f7a-794d-907c-0600cbd16aa9", "Performance & Drivetrain", "All-Wheel Drive (AWD)" },
                    { "0198c37d-3f7a-794d-907c-060112f409e1", "Performance & Drivetrain", "Four-Wheel Drive (4WD)" },
                    { "0198c37d-3f7a-794d-907c-0602419f4278", "Performance & Drivetrain", "Front-Wheel Drive (FWD)" },
                    { "0198c37d-3f7a-794d-907c-0603bdb0daae", "Performance & Drivetrain", "Rear-Wheel Drive (RWD)" },
                    { "0198c37d-3f7a-794d-907c-0606abe14a04", "Performance & Drivetrain", "Turbocharged Engine" },
                    { "0198c37d-3f7a-794d-907c-06076d236f30", "Performance & Drivetrain", "Paddle Shifters" },
                    { "0198c37d-3f7a-794d-907c-0608192c9e37", "Performance & Drivetrain", "Sport Mode" },
                    { "0198c37d-3f7a-794d-907c-06092e931a95", "Performance & Drivetrain", "Hybrid Engine" },
                    { "0198c37d-3f7a-794d-907c-060a9c6c314a", "Performance & Drivetrain", "Electric Vehicle (EV)" },
                    { "0198c37d-3f7a-794d-907c-060be490422a", "Performance & Drivetrain", "Plug-in Hybrid (PHEV)" },
                    { "0198c37d-3f7a-794d-907c-060c687bbb70", "Performance & Drivetrain", "Adaptive Suspension" },
                    { "0198c37d-3f7a-794d-907c-060d0213d065", "Exterior Features", "Sunroof / Moonroof" },
                    { "0198c37d-3f7a-794d-907c-060eac154948", "Exterior Features", "Panoramic Roof" },
                    { "0198c37d-3f7a-794d-907c-060f479a835d", "Exterior Features", "Roof Rack" },
                    { "0198c37d-3f7a-794d-907c-0610ae354f6e", "Exterior Features", "Running Boards / Side Steps" },
                    { "0198c37d-3f7a-794d-907c-0611314b61ba", "Exterior Features", "Tow Hitch" },
                    { "0198c37d-3f7a-794d-907c-061210e66588", "Exterior Features", "Alloy Wheels" },
                    { "0198c3aa-45cb-7105-b8d4-7a377a7f7e54", "Exterior Features", "Premium Wheels" },
                    { "0198c3aa-45cb-7105-b8d4-7a38e767a25f", "Exterior Features", "Fog Lights" },
                    { "0198c3aa-45cb-7105-b8d4-7a391bccb1e7", "Exterior Features", "LED Headlights" },
                    { "0198c3aa-45cb-7105-b8d4-7a3a24fe9317", "Exterior Features", "Automatic Headlights" },
                    { "0198c3aa-45cb-7105-b8d4-7a3bad4a44b8", "Exterior Features", "Heated Side Mirrors" },
                    { "0198c3aa-45cb-7105-b8d4-7a3c9a38c7ca", "Exterior Features", "Power Tailgate / Liftgate" },
                    { "0198c3aa-45cb-7105-b8d4-7a3d009a1e3b", "Interior & Comfort", "Leather Seats" },
                    { "0198c3aa-45cb-7105-b8d4-7a3efbeea60f", "Interior & Comfort", "Heated Seats" },
                    { "0198c3aa-45cc-712f-b1b0-da8160602b1b", "Interior & Comfort", "Ventilated (Cooled) Seats" },
                    { "0198c3aa-45cc-712f-b1b0-da827fa92c10", "Interior & Comfort", "Massaging Seats" },
                    { "0198c3aa-45cc-712f-b1b0-da83d1d7b381", "Interior & Comfort", "Power Adjustable Seats" },
                    { "0198c3aa-45cc-712f-b1b0-da846d833585", "Interior & Comfort", "Memory Seats ( remembers position for multiple drivers)" },
                    { "0198c3aa-45cc-712f-b1b0-da85da2a2899", "Interior & Comfort", "Wood/Alloy Interior Trim" },
                    { "0198c3aa-45cc-712f-b1b0-da86bf2fd67a", "Interior & Comfort", "Panoramic Glass Roof" },
                    { "0198c3aa-45cc-712f-b1b0-da87bb6e7f76", "Interior & Comfort", "Heads-Up Display (HUD)" },
                    { "0198c3aa-45cc-712f-b1b0-da882ca8857b", "Interior & Comfort", "Keyless Entry" },
                    { "0198c3aa-45cc-712f-b1b0-da8966841e38", "Interior & Comfort", "Push Button Start" },
                    { "0198c3aa-45cc-712f-b1b0-da8a78158876", "Interior & Comfort", "Ambient Interior Lighting" },
                    { "0198c3aa-45cc-712f-b1b0-da8b0551855f", "Interior & Comfort", "Dual-Zone Climate Control" },
                    { "0198c3aa-45cc-712f-b1b0-da8cfb6d753d", "Interior & Comfort", "Triple-Zone Climate Control" },
                    { "0198c3aa-45cc-712f-b1b0-da8db366cb87", "Infotainment & Technology", "Bluetooth Connectivity" },
                    { "0198c3aa-45cc-712f-b1b0-da8e1322aecf", "Infotainment & Technology", "Apple CarPlay" },
                    { "0198c3aa-45cc-712f-b1b0-da8fc8fa85cb", "Infotainment & Technology", "Android Auto" },
                    { "0198c3aa-45cc-712f-b1b0-da900ee6bc93", "Infotainment & Technology", "Navigation System" },
                    { "0198c3aa-45cc-712f-b1b0-da91590c6685", "Infotainment & Technology", "Premium Sound System (e.g., Bose, Harman Kardon)" },
                    { "0198c3aa-45cc-712f-b1b0-da923058318c", "Infotainment & Technology", "Upgraded Sound System (e.g., \"Premium\" tier)" },
                    { "0198c3aa-45cc-712f-b1b0-da93bdb3f109", "Infotainment & Technology", "Satellite Radio (e.g., SiriusXM)" },
                    { "0198c3aa-45cc-712f-b1b0-da948b0ca775", "Infotainment & Technology", "HD Radio" },
                    { "0198c3aa-45cc-712f-b1b0-da95f5adcfac", "Infotainment & Technology", "In-Car Wi-Fi Hotspot" },
                    { "0198c3aa-45cc-712f-b1b0-da96cc8be799", "Infotainment & Technology", "Wireless Charging Pad" },
                    { "0198c3bb-6f78-7ea6-a82d-54a9932fc0c1", "Infotainment & Technology", "Multiple USB Ports / USB-C Ports" },
                    { "0198c3bb-6f7a-7184-b3f8-8d644baa9b86", "Infotainment & Technology", "Rear Seat Entertainment (e.g., headrest screens)" },
                    { "0198c3bb-6f7a-7184-b3f8-8d6545056006", "Safety & Driver Assistance", "Adaptive Cruise Control" },
                    { "0198c3bb-6f7a-7184-b3f8-8d665c4f6b7d", "Safety & Driver Assistance", "Lane Keep Assist" },
                    { "0198c3bb-6f7a-7184-b3f8-8d67e9c00727", "Safety & Driver Assistance", "Blind Spot Monitoring" },
                    { "0198c3bb-6f7a-7184-b3f8-8d685fe255d6", "Safety & Driver Assistance", "Rear Cross Traffic Alert" },
                    { "0198c3bb-6f7a-7184-b3f8-8d69982d09b3", "Safety & Driver Assistance", "Forward Collision Warning" },
                    { "0198c3bb-6f7a-7184-b3f8-8d6a733e8b02", "Safety & Driver Assistance", "Automatic Emergency Braking" },
                    { "0198c3bb-6f7a-7184-b3f8-8d6b089fe7ee", "Safety & Driver Assistance", "Pedestrian Detection" },
                    { "0198c3bb-6f7a-7184-b3f8-8d6ca4a86e86", "Safety & Driver Assistance", "Lane Departure Warning" },
                    { "0198c3bb-6f7a-7184-b3f8-8d6d08df5abc", "Infotainment & Technology", "360-Degree Camera" },
                    { "0198c3bb-6f7b-7130-aa6c-701ee8be51aa", "Safety & Driver Assistance", "Parking Sensors (Front & Rear)" },
                    { "0198c3bb-6f7b-7130-aa6c-701feec0e253", "Safety & Driver Assistance", "Hill Descent Control" },
                    { "0198c3bb-6f7b-7130-aa6c-70204277ab61", "Safety & Driver Assistance", "Traction Control" },
                    { "0198c3bb-6f7b-7130-aa6c-7021e101a654", "Safety & Driver Assistance", "Electronic Stability Control" },
                    { "0198c3bb-6f7b-7130-aa6c-702227a1987c", "Cargo & Practicality", "Split-Folding Rear Seats (60/40)" },
                    { "0198c3bb-6f7b-7130-aa6c-7023071ea551", "Cargo & Practicality", "Fold-Flat Passenger Seat" },
                    { "0198c3bb-6f7b-7130-aa6c-702496604deb", "Cargo & Practicality", "Hands-Free Power Tailgate (open with foot motion)" },
                    { "0198c3bb-6f7b-7130-aa6c-7025efdce2c7", "Cargo & Practicality", "Cargo Cover / Tonneau Cover" },
                    { "0198c3bb-6f7b-7130-aa6c-7026eac881b3", "Cargo & Practicality", "Cargo Net" },
                    { "0198c3bb-6f7b-7130-aa6c-70271bc46020", "Cargo & Practicality", "Underfloor Storage" },
                    { "0198c3bb-6f7b-7130-aa6c-7028fbd4a0a6", "Convenience", "Remote Start" },
                    { "0198c3bb-6f7b-7130-aa6c-70297bcbdbf1", "Convenience", "Automatic Parking Assist" },
                    { "0198c3bb-6f7b-7130-aa6c-702a24c2763b", "Convenience", "Rain-Sensing Wipers" },
                    { "0198c3bb-6f7b-7130-aa6c-702b5f744319", "Convenience", "Auto-Dimming Rearview Mirror" },
                    { "0198c3bb-6f7b-7130-aa6c-702cc0220f1c", "Convenience", "Heated Steering Wheel" },
                    { "0198c3bb-6f7b-7130-aa6c-702d71db424a", "Convenience", "Cooled Glovebox" },
                    { "0198c3bb-6f7b-7130-aa6c-702eb7394e98", "Convenience", "Sunshades (Rear Window & Side Windows)" },
                    { "0198fce0-8cc9-767f-84cf-30b75ca9a719", "Safety & Driver Assistance", "Tire Pressure Monitoring System (TPMS)" }
                });

            migrationBuilder.InsertData(
                table: "FuelDeliveries",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { "0198c34a-8ba0-7089-a560-47a4b56add0f", "Carburetor" },
                    { "0198c34a-8ba0-7089-a560-47a5de2fab4e", "Direct Injection" },
                    { "0198c34a-8ba0-7089-a560-47a66e3bc0e9", "EFI (Electronic Fuel Injection)" },
                    { "0198c34a-8ba0-7089-a560-47a76a7833ff", "Multi Point Fuel Injection" },
                    { "0198c34a-8ba0-7089-a560-47a8923e476f", "Sequential Fuel Injection" },
                    { "0198c34a-8ba0-7089-a560-47a9e03b9c8d", "Single Point Fuel Injection" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { "0198c34a-8ba0-7089-a560-478e327a78d4", "Petrol" },
                    { "0198c34a-8ba0-7089-a560-478f770543a1", "Diesel" },
                    { "0198c34a-8ba0-7089-a560-479090f26269", "Gas" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CountryOfOrigin", "MakeName" },
                values: new object[,]
                {
                    { "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "Germany", "Mercedes-Benz" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "Germany", "BMW" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Germany", "Audi" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Germany", "Volkswagen" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "Germany", "Porsche" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3e1d7cfe11", "Japan", "Toyota" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3fe3807112", "Japan", "Honda" },
                    { "0198c363-eb2b-7b9d-9d0f-eb40b5453d55", "Japan", "Nissan" },
                    { "0198c363-eb2b-7b9d-9d0f-eb416a06793c", "Japan", "Mazda" },
                    { "0198c363-eb2b-7b9d-9d0f-eb42030db51d", "Japan", "Subaru" },
                    { "0198c363-eb2b-7b9d-9d0f-eb43b4d761ee", "Japan", "Lexus" },
                    { "0198c363-eb2b-7b9d-9d0f-eb44dfe5fa02", "Japan", "Acura" },
                    { "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "United States", "Ford" },
                    { "0198c363-eb2b-7b9d-9d0f-eb467c2ffef0", "United States", "Chevrolet " },
                    { "0198c363-eb2b-7b9d-9d0f-eb47602a3691", "United States", "Tesla" },
                    { "0198c363-eb2b-7b9d-9d0f-eb484534d0b6", "United States", "Cadillac" },
                    { "0198c363-eb2b-7b9d-9d0f-eb49899f39ab", "United States", "Jeep" },
                    { "0198c363-eb2b-7b9d-9d0f-eb4acc2e0ea9", "Italy", "Ferrari" },
                    { "0198c363-eb2b-7b9d-9d0f-eb4b5d07ad26", "Italy", "Lamborghini" },
                    { "0198c363-eb2b-7b9d-9d0f-eb4cda2d732c", "Italy", "Maserati" },
                    { "0198c363-eb2b-7b9d-9d0f-eb4d9819449d", "Italy", "Fiat" },
                    { "0198c363-eb2b-7b9d-9d0f-eb4e756173da", "United Kingdom", "Rolls-Royce" },
                    { "0198c363-eb2b-7b9d-9d0f-eb4f79aff6cb", "United Kingdom", "Bentley" },
                    { "0198c363-eb2b-7b9d-9d0f-eb503b2475ae", "United Kingdom", "Land Rover" },
                    { "0198c37d-3f7a-794d-907c-05f63f70a55f", "United Kingdom", "Aston Martin" },
                    { "0198c37d-3f7a-794d-907c-05f78cfa2c49", "United Kingdom", "McLaren" },
                    { "0198c37d-3f7a-794d-907c-05f821e2d517", "South Korea", "Hyundai" },
                    { "0198c37d-3f7a-794d-907c-05f92a0ccae6", "South Korea", "Kia" },
                    { "0198c37d-3f7a-794d-907c-05fa405cc86c", "South Korea", "Genesis" },
                    { "0198c37d-3f7a-794d-907c-05fbc97db652", "France", "Renault" },
                    { "0198c37d-3f7a-794d-907c-05fce8a8f028", "France", "Peugeot" },
                    { "0198c37d-3f7a-794d-907c-05fd1317ca31", "France", "Citroën" },
                    { "0198c37d-3f7a-794d-907c-05fe77215249", "Sweden", "Volvo" },
                    { "0198c37d-3f7a-794d-907c-05ff09903782", "Sweden", "Koenigsegg" },
                    { "0198e28b-9717-7847-84b0-8e8622c1b476", "Germany", "Mercedes-AMG" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { "0198c363-eb2b-7b9d-9d0f-eb336e0cb29f", "Manual Transmission" },
                    { "0198c363-eb2b-7b9d-9d0f-eb34e43edba2", "Automatic Transmission" },
                    { "0198c363-eb2b-7b9d-9d0f-eb35b235b53b", "Continuously Variable Transmission (CVT)" },
                    { "0198c363-eb2b-7b9d-9d0f-eb36db29defb", "Automated Manual Transmission" },
                    { "0198c363-eb2b-7b9d-9d0f-eb375f841792", "Intelligent Manual Transmission (iMS)" },
                    { "0198c363-eb2b-7b9d-9d0f-eb3818a1c58e", "Sequential Manual Transmission (SMT)" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeID", "ModelName", "ProductionYear" },
                values: new object[,]
                {
                    { "0198e28b-9717-7847-84b0-8e8622c1b476", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "A-Class", 2019 },
                    { "0198e28b-9717-7847-84b0-8e876d8ec0db", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "C-Class", 1994 },
                    { "0198e28b-9717-7847-84b0-8e88425fc584", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "E-Class", 1994 },
                    { "0198e28b-9717-7847-84b0-8e89e5b712ef", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "S-Class", 1972 },
                    { "0198e28b-9717-7847-84b0-8e8a7fd7794b", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "Maybach S-Class", 2015 },
                    { "0198e28b-9717-7847-84b0-8e8b9de5871b", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "GLA", 2014 },
                    { "0198e28b-9717-7847-84b0-8e8c7bf23728", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "GLB", 2020 },
                    { "0198e28b-9717-7847-84b0-8e8d5d0b99a4", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "GLC", 2016 },
                    { "0198e28b-9717-7847-84b0-8e8e21e574d5", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "GLE", 2016 },
                    { "0198e28b-9717-7847-84b0-8e8f3877be23", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "GLS", 2016 },
                    { "0198e28b-9717-7847-84b0-8e90de03298b", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "G_Class", 1979 },
                    { "0198e28b-9717-7847-84b0-8e918b552f89", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "CLA", 2014 },
                    { "0198e28b-9717-7847-84b0-8e92f6f95b36", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "CLS", 2005 },
                    { "0198e28b-9717-7847-84b0-8e931046377e", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "E-Class Coupe / Cabriolet", 2000 },
                    { "0198e28b-9717-7847-84b0-8e9484765184", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "C-Class Coupe / Cabriolet", 2000 },
                    { "0198e28b-9717-7847-84b0-8e95abfab309", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "S-Class Coupe / Cabriolet", 2000 },
                    { "0198e28b-9717-7847-84b0-8e967eafdcb8", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "SL", 1954 },
                    { "0198e28b-9717-7847-84b0-8e97b1b1ceff", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "SLC", 2016 },
                    { "0198e28b-9717-7847-84b0-8e988b89b3df", "0198e28b-9717-7847-84b0-8e8622c1b476", "C63", 2008 },
                    { "0198e28b-9717-7847-84b0-8e9931eb311d", "0198e28b-9717-7847-84b0-8e8622c1b476", "E63", 2000 },
                    { "0198e28b-9717-7847-84b0-8e9a4b2b6ad4", "0198e28b-9717-7847-84b0-8e8622c1b476", "GT", 2015 },
                    { "0198e28b-9717-7847-84b0-8e9bc6bd2f6a", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "G63", 2000 },
                    { "0198e28b-9717-7847-84b0-8e9cff5178f4", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "EQS", 2022 },
                    { "0198e28b-9717-7847-84b0-8e9da4e387d4", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "EQE", 2023 },
                    { "0198e28b-9717-7847-84b0-8e9e07da2ab0", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "EQS SUV", 2023 },
                    { "0198e28b-9717-7847-84b0-8e9fd49e0cc2", "0198c363-eb2b-7b9d-9d0f-eb39ddf12628", "EQE SUV", 2023 },
                    { "0198e28b-9717-7847-84b0-8ea0b2f4db64", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "2 Series", 2020 },
                    { "0198e28b-9717-7847-84b0-8ea16f9b90f0", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "3 Series", 1975 },
                    { "0198e28b-9717-7847-84b0-8ea2e2f2242a", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "5 Series", 1972 },
                    { "0198e28b-9717-7847-84b0-8ea32da6f641", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "7 Series", 1977 },
                    { "0198e28b-9717-7847-84b0-8ea4be5b3cdf", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "8 Series Gran Coupe", 2019 },
                    { "0198e28b-9717-7847-84b0-8ea540397d43", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X1", 2013 },
                    { "0198e28b-9717-7847-84b0-8ea6a0e37f4a", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X3", 2004 },
                    { "0198e28b-9717-7847-84b0-8ea7714f206b", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X5", 2000 },
                    { "0198e28b-9717-7847-84b0-8ea8b0533a96", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X7", 2019 },
                    { "0198e28b-9717-7847-84b0-8ea94e6a0cd0", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "XM", 2023 },
                    { "0198e28b-9717-7847-84b0-8eaac70e1e9c", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "2 Series Coupe", 2014 },
                    { "0198e28b-9717-7847-84b0-8eabc4d712b7", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "4 Series Coupe / Convertible / Gran Coupe", 2014 },
                    { "0198e28b-9717-7847-84b0-8eacddb6aab0", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "8 Series Coupe / Convertible", 2019 },
                    { "0198e28b-9717-7847-84b0-8eadc04ca785", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "Z4", 2003 },
                    { "0198e28b-9717-7847-84b0-8eae35fbea06", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "M2", 2016 },
                    { "0198e28b-9717-7847-84b0-8eaf4e260592", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "M3", 1986 },
                    { "0198e28b-9717-7847-84b0-8eb050d29140", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "M4", 2014 },
                    { "0198e28b-9717-7847-84b0-8eb15bb48c6c", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "M5", 1985 },
                    { "0198e28b-9717-7847-84b0-8eb22bd0cb07", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X3 M", 2020 },
                    { "0198e28b-9717-7847-84b0-8eb33420a274", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X4 M", 2020 },
                    { "0198e28b-9717-7847-84b0-8eb407018c3d", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X5 M", 2010 },
                    { "0198e28b-9717-7847-84b0-8eb55dc5dfda", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "X6 M", 2010 },
                    { "0198e28b-9718-72e3-a30e-9450a51b9527", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "I4", 2022 },
                    { "0198e28b-9718-72e3-a30e-94514e4e1d7b", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "I5", 2024 },
                    { "0198e2ad-eca1-7d38-83df-51104e5e4638", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "I7", 2023 },
                    { "0198e2ad-eca3-7bfb-bbf3-be43372bf1f9", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "IX", 2022 },
                    { "0198e2ad-eca3-7bfb-bbf3-be44b89dd2a9", "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6", "IX_3", 2021 },
                    { "0198e2ad-eca3-7bfb-bbf3-be45403a4bba", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "A3", 2006 },
                    { "0198e2ad-eca3-7bfb-bbf3-be463d8c74b2", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "A4", 1996 },
                    { "0198e2ad-eca3-7bfb-bbf3-be475c020ef1", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "A5", 2008 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4862547e51", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "S5", 2008 },
                    { "0198e2ad-eca3-7bfb-bbf3-be49911cd930", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "A6", 1995 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4a65870834", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "A7", 2011 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4b3e1ba6f7", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "A8", 1997 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4c6c633f03", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "RS 3", 2017 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4d1e570f4d", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "RS 5", 2010 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4e2e651c47", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "RS 6 Avant", 2021 },
                    { "0198e2ad-eca3-7bfb-bbf3-be4fa4204b9d", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "RS 7", 2014 },
                    { "0198e2ad-eca3-7bfb-bbf3-be50d5c7f7c5", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "RS e tron GT", 2022 },
                    { "0198e2ad-eca3-7bfb-bbf3-be51fd7ad11f", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Q3", 2015 },
                    { "0198e2ad-eca3-7bfb-bbf3-be52f88eb15e", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Q5", 2009 },
                    { "0198e2ad-eca3-7bfb-bbf3-be53a5abb3f8", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Q7", 2007 },
                    { "0198e2ad-eca3-7bfb-bbf3-be54ddbca10c", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Q8", 2019 },
                    { "0198e2ad-eca3-7bfb-bbf3-be55865b904a", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "e-tron Q8", 2019 },
                    { "0198e2ad-eca3-7bfb-bbf3-be56ce66269c", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "SQ5", 2017 },
                    { "0198e2ad-eca3-7bfb-bbf3-be577543b39f", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "SQ7", 2020 },
                    { "0198e2ad-eca3-7bfb-bbf3-be584c8dddbe", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "SQ8", 2020 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5947135eb2", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "RS Q8", 2021 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5aacfa6216", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Q8 e-tron / Sportback", 2024 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5b610c5874", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "Q4 e-tron / Q4 Sportback e-tron", 2022 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5cb7efbe40", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "TT", 2000 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5db7f4d08c", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "R8", 2008 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5e2c0e43b0", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Golf", 1975 },
                    { "0198e2ad-eca3-7bfb-bbf3-be5f5d037cf9", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Jetta", 1980 },
                    { "0198e2ad-eca3-7bfb-bbf3-be604a314dc1", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Passat", 1990 },
                    { "0198e2ad-eca3-7bfb-bbf3-be614ea5cae7", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Arteon", 2019 },
                    { "0198e2ad-eca3-7bfb-bbf3-be62eecc17a3", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Taos", 2021 },
                    { "0198e2ad-eca3-7bfb-bbf3-be632a9312d4", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Tiguan", 2009 },
                    { "0198e2ad-eca3-7bfb-bbf3-be64de9b5a04", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Atlas", 2018 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6550034c31", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Atlas Cross Sport", 2020 },
                    { "0198e2ad-eca3-7bfb-bbf3-be668f9785ab", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Golf SportWagen", 2015 },
                    { "0198e2ad-eca3-7bfb-bbf3-be67c8cf5f12", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "ID. Buzz", 2024 },
                    { "0198e2ad-eca3-7bfb-bbf3-be684f3916bd", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Beetle", 1938 },
                    { "0198e2ad-eca3-7bfb-bbf3-be69b84f0248", "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f", "Eos", 2006 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6a8a1c8c4e", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Explorer", 1991 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6bb5b0e1b5", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Expedition", 1997 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6c182006bf", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Bronco", 1996 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6d46b55647", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Escape", 2001 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6e1be98152", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Edge", 2007 },
                    { "0198e2ad-eca3-7bfb-bbf3-be6fad4840c5", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Mustang Mach-E", 2021 },
                    { "0198e2ad-eca3-7bfb-bbf3-be70a8031a41", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Mustang", 1965 },
                    { "0198e2ad-eca3-7bfb-bbf3-be71069b7f6e", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Fusion", 2006 },
                    { "0198e2ad-eca3-7bfb-bbf3-be725111527f", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Focus", 2000 },
                    { "0198e2ad-eca3-7bfb-bbf3-be7349a97b7b", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "Taurus", 1986 },
                    { "0198fc51-7953-72d6-891c-0d75ea7dc67f", "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c", "GT", 2005 },
                    { "0198fc51-7953-72d6-891c-0d76bcf2595c", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "911", 1964 },
                    { "0198fc51-7953-72d6-891c-0d77b314a2a5", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "718 Boxster", 1996 },
                    { "0198fc51-7953-72d6-891c-0d7842baa732", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "718 Cayman", 2006 },
                    { "0198fc51-7953-72d6-891c-0d7997c2aefd", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "911 GT3 / GT3 RS", 1999 },
                    { "0198fc51-7953-72d6-891c-0d7aacc1f47e", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "911 Turbo / Turbo S", 1975 },
                    { "0198fc51-7953-72d6-891c-0d7b11fee6f4", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "Panamera", 2010 },
                    { "0198fc51-7953-72d6-891c-0d7c0c8e5dac", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "Taycan", 2020 },
                    { "0198fc51-7953-72d6-891c-0d7d232334eb", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "Cayenne", 2003 },
                    { "0198fc51-7953-72d6-891c-0d7e98aeb9fb", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "Macan", 2014 },
                    { "0198fc51-7954-7eb0-aea6-6dfa0a7f8ea8", "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5", "918 Spyder", 2015 },
                    { "0198fcea-2b2e-7342-97c1-7f19bfdf2ba7", "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28", "e-tron GT / RS e-tron GT", 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aspirations",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47aa3acdb58a");

            migrationBuilder.DeleteData(
                table: "Aspirations",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47abace73521");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47916546c9a9");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479224bb6185");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47938977ae7c");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479495a61551");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-4795267320fb");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-4796ba3aa031");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479737348d88");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-4798ee6d43e4");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-4799f3cd22ef");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479ae1fe64af");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479ba551f176");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479cc5b9e724");

            migrationBuilder.DeleteData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479df0e1384b");

            migrationBuilder.DeleteData(
                table: "ChargePorts",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479ec048048e");

            migrationBuilder.DeleteData(
                table: "ChargePorts",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479fd7feef0b");

            migrationBuilder.DeleteData(
                table: "ChargePorts",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a09b2b2ce9");

            migrationBuilder.DeleteData(
                table: "ChargePorts",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a1e5ec96c5");

            migrationBuilder.DeleteData(
                table: "ChargePorts",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a2c8a011dd");

            migrationBuilder.DeleteData(
                table: "ChargePorts",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a3a8bca916");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0600cbd16aa9");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060112f409e1");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0602419f4278");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0603bdb0daae");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0606abe14a04");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-06076d236f30");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0608192c9e37");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-06092e931a95");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060a9c6c314a");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060be490422a");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060c687bbb70");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060d0213d065");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060eac154948");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-060f479a835d");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0610ae354f6e");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-0611314b61ba");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-061210e66588");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a377a7f7e54");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a38e767a25f");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a391bccb1e7");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a3a24fe9317");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a3bad4a44b8");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a3c9a38c7ca");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a3d009a1e3b");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cb-7105-b8d4-7a3efbeea60f");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8160602b1b");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da827fa92c10");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da83d1d7b381");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da846d833585");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da85da2a2899");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da86bf2fd67a");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da87bb6e7f76");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da882ca8857b");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8966841e38");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8a78158876");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8b0551855f");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8cfb6d753d");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8db366cb87");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8e1322aecf");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da8fc8fa85cb");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da900ee6bc93");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da91590c6685");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da923058318c");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da93bdb3f109");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da948b0ca775");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da95f5adcfac");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3aa-45cc-712f-b1b0-da96cc8be799");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f78-7ea6-a82d-54a9932fc0c1");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d644baa9b86");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d6545056006");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d665c4f6b7d");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d67e9c00727");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d685fe255d6");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d69982d09b3");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d6a733e8b02");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d6b089fe7ee");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d6ca4a86e86");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7a-7184-b3f8-8d6d08df5abc");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-701ee8be51aa");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-701feec0e253");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-70204277ab61");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-7021e101a654");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702227a1987c");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-7023071ea551");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702496604deb");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-7025efdce2c7");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-7026eac881b3");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-70271bc46020");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-7028fbd4a0a6");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-70297bcbdbf1");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702a24c2763b");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702b5f744319");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702cc0220f1c");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702d71db424a");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198c3bb-6f7b-7130-aa6c-702eb7394e98");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "0198fce0-8cc9-767f-84cf-30b75ca9a719");

            migrationBuilder.DeleteData(
                table: "FuelDeliveries",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a4b56add0f");

            migrationBuilder.DeleteData(
                table: "FuelDeliveries",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a5de2fab4e");

            migrationBuilder.DeleteData(
                table: "FuelDeliveries",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a66e3bc0e9");

            migrationBuilder.DeleteData(
                table: "FuelDeliveries",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a76a7833ff");

            migrationBuilder.DeleteData(
                table: "FuelDeliveries",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a8923e476f");

            migrationBuilder.DeleteData(
                table: "FuelDeliveries",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-47a9e03b9c8d");

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-478e327a78d4");

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-478f770543a1");

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: "0198c34a-8ba0-7089-a560-479090f26269");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3e1d7cfe11");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3fe3807112");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb40b5453d55");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb416a06793c");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb42030db51d");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb43b4d761ee");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb44dfe5fa02");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb467c2ffef0");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb47602a3691");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb484534d0b6");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb49899f39ab");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb4acc2e0ea9");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb4b5d07ad26");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb4cda2d732c");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb4d9819449d");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb4e756173da");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb4f79aff6cb");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb503b2475ae");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05f63f70a55f");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05f78cfa2c49");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05f821e2d517");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05f92a0ccae6");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05fa405cc86c");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05fbc97db652");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05fce8a8f028");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05fd1317ca31");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05fe77215249");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c37d-3f7a-794d-907c-05ff09903782");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8622c1b476");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e876d8ec0db");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e88425fc584");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e89e5b712ef");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8a7fd7794b");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8b9de5871b");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8c7bf23728");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8d5d0b99a4");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8e21e574d5");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8f3877be23");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e90de03298b");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e918b552f89");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e92f6f95b36");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e931046377e");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9484765184");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e95abfab309");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e967eafdcb8");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e97b1b1ceff");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e988b89b3df");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9931eb311d");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9a4b2b6ad4");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9bc6bd2f6a");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9cff5178f4");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9da4e387d4");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9e07da2ab0");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e9fd49e0cc2");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea0b2f4db64");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea16f9b90f0");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea2e2f2242a");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea32da6f641");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea4be5b3cdf");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea540397d43");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea6a0e37f4a");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea7714f206b");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea8b0533a96");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8ea94e6a0cd0");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eaac70e1e9c");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eabc4d712b7");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eacddb6aab0");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eadc04ca785");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eae35fbea06");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eaf4e260592");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eb050d29140");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eb15bb48c6c");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eb22bd0cb07");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eb33420a274");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eb407018c3d");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8eb55dc5dfda");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9718-72e3-a30e-9450a51b9527");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e28b-9718-72e3-a30e-94514e4e1d7b");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca1-7d38-83df-51104e5e4638");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be43372bf1f9");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be44b89dd2a9");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be45403a4bba");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be463d8c74b2");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be475c020ef1");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4862547e51");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be49911cd930");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4a65870834");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4b3e1ba6f7");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4c6c633f03");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4d1e570f4d");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4e2e651c47");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be4fa4204b9d");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be50d5c7f7c5");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be51fd7ad11f");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be52f88eb15e");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be53a5abb3f8");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be54ddbca10c");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be55865b904a");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be56ce66269c");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be577543b39f");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be584c8dddbe");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5947135eb2");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5aacfa6216");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5b610c5874");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5cb7efbe40");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5db7f4d08c");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5e2c0e43b0");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be5f5d037cf9");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be604a314dc1");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be614ea5cae7");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be62eecc17a3");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be632a9312d4");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be64de9b5a04");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6550034c31");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be668f9785ab");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be67c8cf5f12");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be684f3916bd");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be69b84f0248");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6a8a1c8c4e");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6bb5b0e1b5");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6c182006bf");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6d46b55647");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6e1be98152");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be6fad4840c5");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be70a8031a41");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be71069b7f6e");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be725111527f");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198e2ad-eca3-7bfb-bbf3-be7349a97b7b");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d75ea7dc67f");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d76bcf2595c");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d77b314a2a5");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7842baa732");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7997c2aefd");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7aacc1f47e");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7b11fee6f4");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7c0c8e5dac");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7d232334eb");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7953-72d6-891c-0d7e98aeb9fb");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fc51-7954-7eb0-aea6-6dfa0a7f8ea8");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: "0198fcea-2b2e-7342-97c1-7f19bfdf2ba7");

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb336e0cb29f");

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb34e43edba2");

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb35b235b53b");

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb36db29defb");

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb375f841792");

            migrationBuilder.DeleteData(
                table: "TransmissionTypes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3818a1c58e");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb39ddf12628");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3a07312fa6");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3bcf5b9f28");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3c21ba398f");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb3d5e8f8ba5");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198c363-eb2b-7b9d-9d0f-eb45c6dea49c");

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: "0198e28b-9717-7847-84b0-8e8622c1b476");

            migrationBuilder.DropColumn(
                name: "RangeMiles",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "RangeMiles",
                table: "PowerTrains",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d8d62-fad1-4803-b768-5d22153fd11c",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIJPaldMC5gbqGlIIsVS4XoImsbip88MJgopDPzSpi+ATS94zZd6CX6SunupSvu4Tw==");
        }
    }
}
