using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations.ProductDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightSearch",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OperatingCarrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelerPrices = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DeparturedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivedAt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelSearch",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckoutDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewScore = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalSearch",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    To = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DropOffDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PickUpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropOffAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id3", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightSearch");

            migrationBuilder.DropTable(
                name: "HotelSearch");

            migrationBuilder.DropTable(
                name: "RentalSearch");
        }
    }
}
