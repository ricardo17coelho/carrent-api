using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class addZipCodeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("3f7621bf-3bc6-4d97-9919-1bf079843417"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("88fb2a51-427e-4447-b93e-357cb304ba68"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("cbbf98b8-b9be-4e79-a2f7-179fe4a4e5e1"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("eed4642f-23fa-4972-b867-e699ad44369f"));

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("27713fb4-4ef0-4e06-8357-54fead94f691"), 12m, "Classic" },
                    { new Guid("4868a0b5-33d2-4187-8728-a7481c767da7"), 8m, "Basic" },
                    { new Guid("1cfab1df-f331-4bb2-9e99-c75e86c3cd99"), 20m, "Medium" },
                    { new Guid("e665700e-20e4-4c71-8e2a-6e5190b44026"), 40m, "Luxury" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZipCodes");

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("1cfab1df-f331-4bb2-9e99-c75e86c3cd99"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("27713fb4-4ef0-4e06-8357-54fead94f691"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("4868a0b5-33d2-4187-8728-a7481c767da7"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("e665700e-20e4-4c71-8e2a-6e5190b44026"));

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("3f7621bf-3bc6-4d97-9919-1bf079843417"), 7m, "Classic" },
                    { new Guid("cbbf98b8-b9be-4e79-a2f7-179fe4a4e5e1"), 12m, "Basic" },
                    { new Guid("eed4642f-23fa-4972-b867-e699ad44369f"), 12m, "Medium" },
                    { new Guid("88fb2a51-427e-4447-b93e-357cb304ba68"), 12m, "Luxury" }
                });
        }
    }
}
