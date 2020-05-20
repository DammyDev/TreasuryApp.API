using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreasuryApp.API.Migrations
{
    public partial class IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "EODGLDate", "IsActive", "LastEODDate", "NextEODDate", "NextTradingDate", "TradingDate" },
                values: new object[] { new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(3674), true, new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(2655), new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(3183), new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(2043), new DateTime(2020, 5, 20, 16, 56, 39, 474, DateTimeKind.Local).AddTicks(6589) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "EODGLDate", "LastEODDate", "NextEODDate", "NextTradingDate", "TradingDate" },
                values: new object[] { new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(4807), new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(4796), new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(4803), new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(4781), new DateTime(2020, 5, 20, 16, 56, 39, 476, DateTimeKind.Local).AddTicks(4773) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "EODGLDate", "LastEODDate", "NextEODDate", "NextTradingDate", "TradingDate" },
                values: new object[] { new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(8149), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(7088), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(7617), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(6465), new DateTime(2020, 5, 19, 0, 9, 40, 844, DateTimeKind.Local).AddTicks(2857) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "EODGLDate", "LastEODDate", "NextEODDate", "NextTradingDate", "TradingDate" },
                values: new object[] { new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9274), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9263), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9267), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9244), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9236) });
        }
    }
}
