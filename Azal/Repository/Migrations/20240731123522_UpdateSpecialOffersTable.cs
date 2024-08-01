using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdateSpecialOffersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialOffersTransLates_Blogs_BlogId",
                table: "SpecialOffersTransLates");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialOffersTransLates_SpecialOffers_SpecialOfferId",
                table: "SpecialOffersTransLates");

            migrationBuilder.DropIndex(
                name: "IX_SpecialOffersTransLates_BlogId",
                table: "SpecialOffersTransLates");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "SpecialOffersTransLates");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialOfferId",
                table: "SpecialOffersTransLates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialOffersTransLates_SpecialOffers_SpecialOfferId",
                table: "SpecialOffersTransLates",
                column: "SpecialOfferId",
                principalTable: "SpecialOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialOffersTransLates_SpecialOffers_SpecialOfferId",
                table: "SpecialOffersTransLates");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialOfferId",
                table: "SpecialOffersTransLates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "SpecialOffersTransLates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffersTransLates_BlogId",
                table: "SpecialOffersTransLates",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialOffersTransLates_Blogs_BlogId",
                table: "SpecialOffersTransLates",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialOffersTransLates_SpecialOffers_SpecialOfferId",
                table: "SpecialOffersTransLates",
                column: "SpecialOfferId",
                principalTable: "SpecialOffers",
                principalColumn: "Id");
        }
    }
}
