using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class Initial_BookGenre6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Books_BookId1",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Genres_GenreId1",
                table: "BookGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenres",
                table: "BookGenres");

            migrationBuilder.RenameTable(
                name: "BookGenres",
                newName: "BookGenre");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_GenreId1",
                table: "BookGenre",
                newName: "IX_BookGenre_GenreId1");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_BookId1",
                table: "BookGenre",
                newName: "IX_BookGenre_BookId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre",
                columns: new[] { "BookId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Books_BookId1",
                table: "BookGenre",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_GenreId1",
                table: "BookGenre",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Books_BookId1",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenreId1",
                table: "BookGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre");

            migrationBuilder.RenameTable(
                name: "BookGenre",
                newName: "BookGenres");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_GenreId1",
                table: "BookGenres",
                newName: "IX_BookGenres_GenreId1");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_BookId1",
                table: "BookGenres",
                newName: "IX_BookGenres_BookId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenres",
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Books_BookId1",
                table: "BookGenres",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Genres_GenreId1",
                table: "BookGenres",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
