using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    public partial class addCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_ZipCodes_ZipId",
                        column: x => x.ZipId,
                        principalTable: "ZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("7d054ffe-f9c0-4d4d-bb6d-d0215bb900b8"), 12m, "Classic" },
                    { new Guid("bda13588-1e50-4bde-9ea4-627544df15f9"), 8m, "Basic" },
                    { new Guid("79e80863-92b7-48c0-9198-55677a204def"), 20m, "Medium" },
                    { new Guid("ec1e8aaa-e5ff-4358-ae72-820f95940a31"), 40m, "Luxury" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ZipId",
                table: "Customers",
                column: "ZipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("79e80863-92b7-48c0-9198-55677a204def"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("7d054ffe-f9c0-4d4d-bb6d-d0215bb900b8"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("bda13588-1e50-4bde-9ea4-627544df15f9"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("ec1e8aaa-e5ff-4358-ae72-820f95940a31"));

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
    }
}
