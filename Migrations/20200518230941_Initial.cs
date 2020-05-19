using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreasuryApp.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    SwiftAddress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ReportingCurrency = table.Column<string>(nullable: false),
                    ParentEntity = table.Column<string>(nullable: true),
                    SuspenseGLAccount = table.Column<string>(nullable: false),
                    TradingDate = table.Column<DateTime>(nullable: false),
                    NextTradingDate = table.Column<DateTime>(nullable: false),
                    LastEODDate = table.Column<DateTime>(nullable: false),
                    NextEODDate = table.Column<DateTime>(nullable: false),
                    EODGLDate = table.Column<DateTime>(nullable: false),
                    MRSName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Country", "EODGLDate", "LastEODDate", "MRSName", "Name", "NextEODDate", "NextTradingDate", "ParentEntity", "PhoneNumber", "PhysicalAddress", "ReportingCurrency", "ShortName", "SuspenseGLAccount", "SwiftAddress", "TradingDate" },
                values: new object[] { 100, "Nigeria", new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(8149), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(7088), "FF", "Beta Highdeas InfoTech", new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(7617), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(6465), "XXX", "08030721539", "57 Marina Rd, Lagos, ", "USD", "BetaHitech", "900USD100000", "XXXYYYZZZ", new DateTime(2020, 5, 19, 0, 9, 40, 844, DateTimeKind.Local).AddTicks(2857) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Country", "EODGLDate", "LastEODDate", "MRSName", "Name", "NextEODDate", "NextTradingDate", "ParentEntity", "PhoneNumber", "PhysicalAddress", "ReportingCurrency", "ShortName", "SuspenseGLAccount", "SwiftAddress", "TradingDate" },
                values: new object[] { 101, "Nigeria", new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9274), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9263), "QQ", "Bisi and Sons Ltd", new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9267), new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9244), "XXX", "09056570001", "House 59, Ijapo Estate Rd, Akure ", "GBP", "Beecee", "900GBP500000", "XXXYYYZZZ", new DateTime(2020, 5, 19, 0, 9, 40, 845, DateTimeKind.Local).AddTicks(9236) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
