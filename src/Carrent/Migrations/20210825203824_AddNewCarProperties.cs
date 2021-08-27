using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class AddNewCarProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("02d2e557-b02b-41eb-b76a-9286b3687e3a"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("0763d9ef-670a-49c6-8c27-3f6d4c2049e8"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("a814e87e-fe7d-465f-a1b2-5086bd3f5ff0"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("e25b38e1-c24d-4e96-a6b7-1c4edc8288f6"));

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Kilometers",
                table: "Cars",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationYear",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("fc710c14-9184-4eab-b5d2-11b167544d67"), 12m, "Classic" },
                    { new Guid("a82d4e14-e93e-4dc4-b798-1d7c282e1928"), 8m, "Basic" },
                    { new Guid("c1bee0db-cd2a-4c7c-9603-11b0761e3ef4"), 20m, "Medium" },
                    { new Guid("e981f7c6-d3b4-4827-8305-3bfc276ddc1a"), 40m, "Luxury" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("a82d4e14-e93e-4dc4-b798-1d7c282e1928"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("c1bee0db-cd2a-4c7c-9603-11b0761e3ef4"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("e981f7c6-d3b4-4827-8305-3bfc276ddc1a"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("fc710c14-9184-4eab-b5d2-11b167544d67"));

            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RegistrationYear",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("a814e87e-fe7d-465f-a1b2-5086bd3f5ff0"), 12m, "Classic" },
                    { new Guid("0763d9ef-670a-49c6-8c27-3f6d4c2049e8"), 8m, "Basic" },
                    { new Guid("02d2e557-b02b-41eb-b76a-9286b3687e3a"), 20m, "Medium" },
                    { new Guid("e25b38e1-c24d-4e96-a6b7-1c4edc8288f6"), 40m, "Luxury" }
                });
        }
    }
}
