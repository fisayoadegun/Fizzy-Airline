using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class sequencemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 6, 9, 20, 42, 11, 71, DateTimeKind.Local).AddTicks(93), new DateTime(2022, 6, 8, 20, 42, 11, 71, DateTimeKind.Local).AddTicks(1221), new DateTime(2022, 6, 8, 20, 42, 11, 69, DateTimeKind.Local).AddTicks(5408) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 9, 59, 204, DateTimeKind.Local).AddTicks(289), new DateTime(2022, 5, 22, 12, 9, 59, 204, DateTimeKind.Local).AddTicks(2652), new DateTime(2022, 5, 22, 12, 9, 59, 201, DateTimeKind.Local).AddTicks(5499) });
        }
    }
}
