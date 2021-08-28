using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    public partial class AddRentalContract : Migration
    {
        [ExcludeFromCodeCoverage]
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RentalContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CarClasses",
                columns: new[] { "Id", "PricePerDay", "Type" },
                values: new object[,]
                {
                    { new Guid("f7212e63-6933-4465-a6e2-4c39b5aa316e"), 12m, "Classic" },
                    { new Guid("45c237c2-4b30-4980-9156-51db959d3a46"), 8m, "Basic" },
                    { new Guid("f99428eb-107a-43cd-8831-e6a97e16add0"), 20m, "Medium" },
                    { new Guid("dc7c8141-9c2a-4b8e-a251-43adc64b3387"), 40m, "Luxury" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_ReservationId",
                table: "RentalContracts",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalContracts");

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("45c237c2-4b30-4980-9156-51db959d3a46"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("dc7c8141-9c2a-4b8e-a251-43adc64b3387"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("f7212e63-6933-4465-a6e2-4c39b5aa316e"));

            migrationBuilder.DeleteData(
                table: "CarClasses",
                keyColumn: "Id",
                keyValue: new Guid("f99428eb-107a-43cd-8831-e6a97e16add0"));

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
    }
}
