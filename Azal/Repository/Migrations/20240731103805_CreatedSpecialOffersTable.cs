using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedSpecialOffersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffersTransLates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialOfferId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffersTransLates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialOffersTransLates_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialOffersTransLates_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialOffersTransLates_SpecialOffers_SpecialOfferId",
                        column: x => x.SpecialOfferId,
                        principalTable: "SpecialOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffersTransLates_BlogId",
                table: "SpecialOffersTransLates",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffersTransLates_LanguageId",
                table: "SpecialOffersTransLates",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffersTransLates_SpecialOfferId",
                table: "SpecialOffersTransLates",
                column: "SpecialOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialOffersTransLates");

            migrationBuilder.DropTable(
                name: "SpecialOffers");
        }
    }
}
