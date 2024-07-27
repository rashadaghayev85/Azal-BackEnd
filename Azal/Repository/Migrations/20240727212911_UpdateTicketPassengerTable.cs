using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateTicketPassengerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Passengers",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentExpiryDate",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DocumentExpiryDate",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Passengers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SeatNumber",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
