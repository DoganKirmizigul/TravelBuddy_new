using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations.ProductDb
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SearchDateTime",
                table: "RentalSearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchedBy",
                table: "RentalSearch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SearchDateTime",
                table: "HotelSearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SearchDateTime",
                table: "FlightSearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchedBy",
                table: "FlightSearch",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchDateTime",
                table: "RentalSearch");

            migrationBuilder.DropColumn(
                name: "SearchedBy",
                table: "RentalSearch");

            migrationBuilder.DropColumn(
                name: "SearchDateTime",
                table: "HotelSearch");

            migrationBuilder.DropColumn(
                name: "SearchDateTime",
                table: "FlightSearch");

            migrationBuilder.DropColumn(
                name: "SearchedBy",
                table: "FlightSearch");
        }
    }
}
