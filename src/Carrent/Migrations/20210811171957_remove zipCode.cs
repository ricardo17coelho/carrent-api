using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class removezipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ZipCodes_ZipId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ZipCodes");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ZipId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("29a3537e-f2b5-44ac-8eb1-e0651d19daba"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("6ec1a127-b6d8-453b-8d1c-1d0f3bcc7530"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("7c466448-1ffd-4e55-82bf-c5ca3be8ddbc"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("a8b28a4c-cadb-47b4-a7a3-b32ee1e89168"));

            migrationBuilder.DropColumn(
                name: "ZipId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("4d808400-9228-4dac-9cf0-9a4a62808457"), 12m, "Classic" },
                    { new Guid("72cd25b9-19f4-4081-85bf-54177a56f273"), 8m, "Basic" },
                    { new Guid("56f134ab-c844-4bfd-8f7d-f354eaa9cc5c"), 20m, "Medium" },
                    { new Guid("d2be8c67-d1c8-4412-8ba1-bdc0cff4ff19"), 40m, "Luxury" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("4d808400-9228-4dac-9cf0-9a4a62808457"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("56f134ab-c844-4bfd-8f7d-f354eaa9cc5c"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("72cd25b9-19f4-4081-85bf-54177a56f273"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("d2be8c67-d1c8-4412-8ba1-bdc0cff4ff19"));

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "ZipId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("7c466448-1ffd-4e55-82bf-c5ca3be8ddbc"), 12m, "Classic" },
                    { new Guid("6ec1a127-b6d8-453b-8d1c-1d0f3bcc7530"), 8m, "Basic" },
                    { new Guid("29a3537e-f2b5-44ac-8eb1-e0651d19daba"), 20m, "Medium" },
                    { new Guid("a8b28a4c-cadb-47b4-a7a3-b32ee1e89168"), 40m, "Luxury" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ZipId",
                table: "Customers",
                column: "ZipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ZipCodes_ZipId",
                table: "Customers",
                column: "ZipId",
                principalTable: "ZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
