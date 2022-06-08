using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class ticketboardingpassupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 22, 8, 59, 49, 325, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 5, 21, 8, 59, 49, 325, DateTimeKind.Local).AddTicks(4211), new DateTime(2022, 5, 21, 8, 59, 49, 323, DateTimeKind.Local).AddTicks(5911) });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Passenger_id",
                table: "Ticket",
                column: "Passenger_id");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPass_Passenger_id",
                table: "BoardingPass",
                column: "Passenger_id");

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPass_Ticket_id",
                table: "BoardingPass",
                column: "Ticket_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPass_Passengers_Passenger_id",
                table: "BoardingPass",
                column: "Passenger_id",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPass_Ticket_Ticket_id",
                table: "BoardingPass",
                column: "Ticket_id",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passengers_Passenger_id",
                table: "Ticket",
                column: "Passenger_id",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPass_Passengers_Passenger_id",
                table: "BoardingPass");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPass_Ticket_Ticket_id",
                table: "BoardingPass");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passengers_Passenger_id",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_Passenger_id",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_BoardingPass_Passenger_id",
                table: "BoardingPass");

            migrationBuilder.DropIndex(
                name: "IX_BoardingPass_Ticket_id",
                table: "BoardingPass");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 22, 8, 55, 41, 155, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 5, 21, 8, 55, 41, 155, DateTimeKind.Local).AddTicks(9972), new DateTime(2022, 5, 21, 8, 55, 41, 154, DateTimeKind.Local).AddTicks(2258) });
        }
    }
}
