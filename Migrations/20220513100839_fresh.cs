using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class fresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptTerms = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordReset = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight_Attendants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Attendants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PilotLicense = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airplane_Id = table.Column<int>(type: "int", nullable: false),
                    FirstPilotId = table.Column<int>(type: "int", nullable: false),
                    SecondPilotId = table.Column<int>(type: "int", nullable: false),
                    FirstFlightAttendantId = table.Column<int>(type: "int", nullable: false),
                    SecondFlightAttendantId = table.Column<int>(type: "int", nullable: false),
                    ThirdFlightAttendantId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoingFromId = table.Column<int>(type: "int", nullable: false),
                    ArrivingAtId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departed = table.Column<bool>(type: "bit", nullable: false),
                    ArrivedAtDestination = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_Airplane_Id",
                        column: x => x.Airplane_Id,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Flight_Attendants_FirstFlightAttendantId",
                        column: x => x.FirstFlightAttendantId,
                        principalTable: "Flight_Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Flight_Attendants_SecondFlightAttendantId",
                        column: x => x.SecondFlightAttendantId,
                        principalTable: "Flight_Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Flight_Attendants_ThirdFlightAttendantId",
                        column: x => x.ThirdFlightAttendantId,
                        principalTable: "Flight_Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Locations_ArrivingAtId",
                        column: x => x.ArrivingAtId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Locations_GoingFromId",
                        column: x => x.GoingFromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_FirstPilotId",
                        column: x => x.FirstPilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_SecondPilotId",
                        column: x => x.SecondPilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "Manufacturer", "Model", "NumberOfSeats" },
                values: new object[,]
                {
                    { 1, "Airbus", "Airbus A350-1000", 3 },
                    { 2, "Antonov", "Antonov AN-124 Ruslan", 3 }
                });

            migrationBuilder.InsertData(
                table: "Flight_Attendants",
                columns: new[] { "Id", "ContactNumber", "Designation", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "87368396", "test", "Busola", "Adegun" },
                    { 2, "87368347396", "test", "Tope", "Fajuyi" },
                    { 3, "0737373", "test", "Shade", "Francis" },
                    { 4, "6453353", "test", "Ola", "John" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "LocationName" },
                values: new object[,]
                {
                    { 1, "Lagos" },
                    { 2, "Enugu" },
                    { 3, "Abuja" }
                });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "ContactNumber", "Designation", "FirstName", "LastName", "PilotLicense" },
                values: new object[,]
                {
                    { 1, "07069482433", "test", "Wale", "Akinyemi", "test" },
                    { 2, "84387936", "test", "Fisayo", "Emma", "test" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airplane_Id", "ArrivalDate", "ArrivedAtDestination", "ArrivingAtId", "CreatedAt", "CreatedBy", "Departed", "DepartureDate", "FirstFlightAttendantId", "FirstPilotId", "GoingFromId", "Price", "SecondFlightAttendantId", "SecondPilotId", "ThirdFlightAttendantId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, 1, new DateTime(2022, 5, 14, 11, 8, 38, 794, DateTimeKind.Local).AddTicks(2738), false, 2, new DateTime(2022, 5, 13, 11, 8, 38, 794, DateTimeKind.Local).AddTicks(3708), "Fisayo.Adegun", false, new DateTime(2022, 5, 13, 11, 8, 38, 792, DateTimeKind.Local).AddTicks(9640), 1, 1, 1, 107500.0, 2, 2, 4, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Airplane_Id",
                table: "Flights",
                column: "Airplane_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivingAtId",
                table: "Flights",
                column: "ArrivingAtId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FirstFlightAttendantId",
                table: "Flights",
                column: "FirstFlightAttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FirstPilotId",
                table: "Flights",
                column: "FirstPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_GoingFromId",
                table: "Flights",
                column: "GoingFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_SecondFlightAttendantId",
                table: "Flights",
                column: "SecondFlightAttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_SecondPilotId",
                table: "Flights",
                column: "SecondPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ThirdFlightAttendantId",
                table: "Flights",
                column: "ThirdFlightAttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Flight_Attendants");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
