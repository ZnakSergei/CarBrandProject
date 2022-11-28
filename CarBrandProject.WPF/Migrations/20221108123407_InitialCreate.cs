using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBrandProject.WPF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BrandName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModelName = table.Column<string>(type: "TEXT", nullable: false),
                    TypeOfFuel = table.Column<string>(type: "TEXT", nullable: false),
                    DateOnMarket = table.Column<string>(type: "TEXT", nullable: false),
                    ModelClass = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    PassangerCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAvalable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
