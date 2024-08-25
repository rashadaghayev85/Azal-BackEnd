using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatePopularDirectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_usd",
                table: "PopularDirections",
                newName: "PriceEconom");

            migrationBuilder.RenameColumn(
                name: "Price_azn",
                table: "PopularDirections",
                newName: "PriceBiznes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceEconom",
                table: "PopularDirections",
                newName: "Price_usd");

            migrationBuilder.RenameColumn(
                name: "PriceBiznes",
                table: "PopularDirections",
                newName: "Price_azn");
        }
    }
}
