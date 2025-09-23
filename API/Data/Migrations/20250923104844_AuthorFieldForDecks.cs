using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthorFieldForDecks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Decks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_AuthorId",
                table: "Decks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_AspNetUsers_AuthorId",
                table: "Decks",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_AspNetUsers_AuthorId",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_AuthorId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Decks");
        }
    }
}
