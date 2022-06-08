using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class cleanupagainss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BoardingPasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BoardingPasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BoardingPasses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BoardingPasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 9, 59, 204, DateTimeKind.Local).AddTicks(289), new DateTime(2022, 5, 22, 12, 9, 59, 204, DateTimeKind.Local).AddTicks(2652), new DateTime(2022, 5, 22, 12, 9, 59, 201, DateTimeKind.Local).AddTicks(5499) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BoardingPasses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BoardingPasses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BoardingPasses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BoardingPasses");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 8, 57, 252, DateTimeKind.Local).AddTicks(1452), new DateTime(2022, 5, 22, 12, 8, 57, 252, DateTimeKind.Local).AddTicks(2667), new DateTime(2022, 5, 22, 12, 8, 57, 250, DateTimeKind.Local).AddTicks(4146) });
        }
    }
}
