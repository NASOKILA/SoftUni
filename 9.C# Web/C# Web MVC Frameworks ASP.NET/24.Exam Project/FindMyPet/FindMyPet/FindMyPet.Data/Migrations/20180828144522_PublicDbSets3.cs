using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyPet.Data.Migrations
{
    public partial class PublicDbSets3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_FounderId1",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId1",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_FounderId1",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_OwnerId1",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "FounderId1",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Pets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FounderId",
                table: "Pets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FounderId",
                table: "Pets",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_FounderId",
                table: "Pets",
                column: "FounderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_FounderId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_FounderId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FounderId",
                table: "Pets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FounderId1",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Pets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FounderId1",
                table: "Pets",
                column: "FounderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId1",
                table: "Pets",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_FounderId1",
                table: "Pets",
                column: "FounderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId1",
                table: "Pets",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
