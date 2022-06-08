using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class cleanupagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_BoardingPasses_BoardingPassId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BoardingPassId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BoardingPassId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "Ticket_id");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 11, 15, 51, 553, DateTimeKind.Local).AddTicks(9418), new DateTime(2022, 5, 22, 11, 15, 51, 554, DateTimeKind.Local).AddTicks(727), new DateTime(2022, 5, 22, 11, 15, 51, 552, DateTimeKind.Local).AddTicks(2217) });

            migrationBuilder.CreateIndex(
                name: "IX_BoardingPasses_Ticket_id",
                table: "BoardingPasses",
                column: "Ticket_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardingPasses_Tickets_Ticket_id",
                table: "BoardingPasses",
                column: "Ticket_id",
                principalTable: "Tickets",
                principalColumn: "Ticket_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardingPasses_Tickets_Ticket_id",
                table: "BoardingPasses");

            migrationBuilder.DropIndex(
                name: "IX_BoardingPasses_Ticket_id",
                table: "BoardingPasses");

            migrationBuilder.RenameColumn(
                name: "Ticket_id",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BoardingPassId",
                table: "Tickets",
                type: "int",
                nullable: true);

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
                name: "FK_Tickets_BoardingPasses_BoardingPassId",
                table: "Tickets",
                column: "BoardingPassId",
                principalTable: "BoardingPasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
