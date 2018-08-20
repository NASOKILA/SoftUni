using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Data.Migrations
{
    public partial class AddingDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowersBooks_Books_BookId",
                table: "BorrowersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowersBooks_Borrowers_BorrowerId",
                table: "BorrowersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowersMovies_Movie_MovieId",
                table: "BorrowersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.RenameTable(
                name: "BorrowersBooks",
                newName: "BorrowedBooks");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_DirectorId",
                table: "Movies",
                newName: "IX_Movies_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowersBooks_BorrowerId",
                table: "BorrowedBooks",
                newName: "IX_BorrowedBooks_BorrowerId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BorrowersMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BorrowedBooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks",
                columns: new[] { "BookId", "BorrowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Books_BookId",
                table: "BorrowedBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Borrowers_BorrowerId",
                table: "BorrowedBooks",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowersMovies_Movies_MovieId",
                table: "BorrowersMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Books_BookId",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Borrowers_BorrowerId",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowersMovies_Movies_MovieId",
                table: "BorrowersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BorrowersMovies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BorrowedBooks");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameTable(
                name: "BorrowedBooks",
                newName: "BorrowersBooks");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_DirectorId",
                table: "Movie",
                newName: "IX_Movie_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedBooks_BorrowerId",
                table: "BorrowersBooks",
                newName: "IX_BorrowersBooks_BorrowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks",
                columns: new[] { "BookId", "BorrowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowersBooks_Books_BookId",
                table: "BorrowersBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowersBooks_Borrowers_BorrowerId",
                table: "BorrowersBooks",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowersMovies_Movie_MovieId",
                table: "BorrowersMovies",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
