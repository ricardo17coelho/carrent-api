using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class addReservationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

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
        }
    }
}
