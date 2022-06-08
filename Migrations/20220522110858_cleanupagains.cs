using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fizzy_Airline.Migrations
{
    public partial class cleanupagains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 8, 57, 252, DateTimeKind.Local).AddTicks(1452), new DateTime(2022, 5, 22, 12, 8, 57, 252, DateTimeKind.Local).AddTicks(2667), new DateTime(2022, 5, 22, 12, 8, 57, 250, DateTimeKind.Local).AddTicks(4146) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "CreatedAt", "DepartureDate" },
                values: new object[] { new DateTime(2022, 5, 23, 11, 15, 51, 553, DateTimeKind.Local).AddTicks(9418), new DateTime(2022, 5, 22, 11, 15, 51, 554, DateTimeKind.Local).AddTicks(727), new DateTime(2022, 5, 22, 11, 15, 51, 552, DateTimeKind.Local).AddTicks(2217) });
        }
    }
}
