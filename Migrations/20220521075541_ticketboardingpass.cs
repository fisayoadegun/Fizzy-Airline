using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class ticketboardingpass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardingPass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_id = table.Column<int>(type: "int", nullable: false),
                    Passenger_id = table.Column<int>(type: "int", nullable: false),
                    Ticket_id = table.Column<int>(type: "int", nullable: false),
                    HasCheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    HasBoarded = table.Column<bool>(type: "bit", nullable: false),
                    Luggage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingPass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardingPass_Flights_Flight_id",
                        column: x => x.Flight_id,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passenger_id = table.Column<int>(type: "int", nullable: false),
                    Flight_id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    GoingFromId = table.Column<int>(type: "int", nullable: false),
                    ArrivingAtId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_Flight_id",
                        column: x => x.Flight_id,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Locations_ArrivingAtId",
                        column: x => x.ArrivingAtId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Locations_GoingFromId",
                        column: x => x.GoingFromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 22, 8, 55, 41, 155, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 5, 21, 8, 55, 41, 155, DateTimeKind.Local).AddTicks(9972), new DateTime(2022, 5, 21, 8, 55, 41, 154, DateTimeKind.Local).AddTicks(2258) });

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPass_Flight_id",
                table: "BoardingPass",
                column: "Flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ArrivingAtId",
                table: "Ticket",
                column: "ArrivingAtId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Flight_id",
                table: "Ticket",
                column: "Flight_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_GoingFromId",
                table: "Ticket",
                column: "GoingFromId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardingPass");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 14, 11, 8, 38, 794, DateTimeKind.Local).AddTicks(2738), new DateTime(2022, 5, 13, 11, 8, 38, 794, DateTimeKind.Local).AddTicks(3708), new DateTime(2022, 5, 13, 11, 8, 38, 792, DateTimeKind.Local).AddTicks(9640) });
        }
    }
}
