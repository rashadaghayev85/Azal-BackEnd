using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class EditFlightTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_usd",
                table: "Flights",
                newName: "Price_econom");

            migrationBuilder.RenameColumn(
                name: "Price_azn",
                table: "Flights",
                newName: "Price_biznes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_econom",
                table: "Flights",
                newName: "Price_usd");

            migrationBuilder.RenameColumn(
                name: "Price_biznes",
                table: "Flights",
                newName: "Price_azn");
        }
    }
}
