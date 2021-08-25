using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    public partial class AddBaseDataCarTypeAndCarBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeId",
                table: "Cars",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBrands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_TypeId",
                table: "Cars",
                column: "TypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBrands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_TypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TypeId",
                table: "Cars");

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

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Cars",
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
    }
}
