using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Tickets",
                newName: "Price_usd");

            migrationBuilder.AddColumn<int>(
                name: "Price_az",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_az",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Price_usd",
                table: "Tickets",
                newName: "Price");
        }
    }
}
