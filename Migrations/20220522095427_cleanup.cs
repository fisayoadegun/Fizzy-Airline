using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPass_Flights_Flight_id",
                table: "BoardingPass");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPass_Passengers_Passenger_id",
                table: "BoardingPass");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPass_Ticket_Ticket_id",
                table: "BoardingPass");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_Flight_id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Locations_ArrivingAtId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Locations_GoingFromId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passengers_Passenger_id",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardingPass",
                table: "BoardingPass");

            migrationBuilder.DropIndex(
                name: "IX_BoardingPass_Ticket_id",
                table: "BoardingPass");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "BoardingPass",
                newName: "BoardingPasses");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Passenger_id",
                table: "Tickets",
                newName: "IX_Tickets_Passenger_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_GoingFromId",
                table: "Tickets",
                newName: "IX_Tickets_GoingFromId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Flight_id",
                table: "Tickets",
                newName: "IX_Tickets_Flight_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ArrivingAtId",
                table: "Tickets",
                newName: "IX_Tickets_ArrivingAtId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardingPass_Passenger_id",
                table: "BoardingPasses",
                newName: "IX_BoardingPasses_Passenger_id");

            migrationBuilder.RenameIndex(
                name: "IX_BoardingPass_Flight_id",
                table: "BoardingPasses",
                newName: "IX_BoardingPasses_Flight_id");

            migrationBuilder.AddColumn<int>(
                name: "BoardingPassId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardingPasses",
                table: "BoardingPasses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 10, 54, 26, 242, DateTimeKind.Local).AddTicks(2698), new DateTime(2022, 5, 22, 10, 54, 26, 242, DateTimeKind.Local).AddTicks(3688), new DateTime(2022, 5, 22, 10, 54, 26, 239, DateTimeKind.Local).AddTicks(973) });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BoardingPassId",
                table: "Tickets",
                column: "BoardingPassId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPasses_Flights_Flight_id",
                table: "BoardingPasses",
                column: "Flight_id",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPasses_Passengers_Passenger_id",
                table: "BoardingPasses",
                column: "Passenger_id",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_BoardingPasses_BoardingPassId",
                table: "Tickets",
                column: "BoardingPassId",
                principalTable: "BoardingPasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_Flight_id",
                table: "Tickets",
                column: "Flight_id",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_ArrivingAtId",
                table: "Tickets",
                column: "ArrivingAtId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_GoingFromId",
                table: "Tickets",
                column: "GoingFromId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_Passenger_id",
                table: "Tickets",
                column: "Passenger_id",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPasses_Flights_Flight_id",
                table: "BoardingPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPasses_Passengers_Passenger_id",
                table: "BoardingPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_BoardingPasses_BoardingPassId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_Flight_id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_ArrivingAtId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_GoingFromId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_Passenger_id",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BoardingPassId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardingPasses",
                table: "BoardingPasses");

            migrationBuilder.DropColumn(
                name: "BoardingPassId",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "BoardingPasses",
                newName: "BoardingPass");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Passenger_id",
                table: "Ticket",
                newName: "IX_Ticket_Passenger_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_GoingFromId",
                table: "Ticket",
                newName: "IX_Ticket_GoingFromId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Flight_id",
                table: "Ticket",
                newName: "IX_Ticket_Flight_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ArrivingAtId",
                table: "Ticket",
                newName: "IX_Ticket_ArrivingAtId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardingPasses_Passenger_id",
                table: "BoardingPass",
                newName: "IX_BoardingPass_Passenger_id");

            migrationBuilder.RenameIndex(
                name: "IX_BoardingPasses_Flight_id",
                table: "BoardingPass",
                newName: "IX_BoardingPass_Flight_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardingPass",
                table: "BoardingPass",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 22, 8, 59, 49, 325, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 5, 21, 8, 59, 49, 325, DateTimeKind.Local).AddTicks(4211), new DateTime(2022, 5, 21, 8, 59, 49, 323, DateTimeKind.Local).AddTicks(5911) });

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPass_Ticket_id",
                table: "BoardingPass",
                column: "Ticket_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPass_Flights_Flight_id",
                table: "BoardingPass",
                column: "Flight_id",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Ticket_Flights_Flight_id",
                table: "Ticket",
                column: "Flight_id",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Locations_ArrivingAtId",
                table: "Ticket",
                column: "ArrivingAtId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Locations_GoingFromId",
                table: "Ticket",
                column: "GoingFromId",
                principalTable: "Locations",
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
    }
}
