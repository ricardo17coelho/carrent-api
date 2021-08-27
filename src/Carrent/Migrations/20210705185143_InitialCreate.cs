using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "CarClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClassId",
                table: "Cars",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarClasses");
        }
    }
}
