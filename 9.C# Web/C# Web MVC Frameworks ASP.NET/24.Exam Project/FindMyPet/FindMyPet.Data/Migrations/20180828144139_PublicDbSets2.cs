using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyPet.Data.Migrations
{
    public partial class PublicDbSets2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pet_PetId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_AspNetUsers_FounderId1",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_AspNetUsers_OwnerId1",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "FlyingSpeedPerKm",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "WingsSizeInCentimeters",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "ClimbsOnTrees",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "HatesMouses",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "HatesCats",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "IsFrendyToPeople",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_OwnerId1",
                table: "Pets",
                newName: "IX_Pets_OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_FounderId1",
                table: "Pets",
                newName: "IX_Pets_FounderId1");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Pets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pets_PetId",
                table: "Comments",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pets_PetId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_FounderId1",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_OwnerId1",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OwnerId1",
                table: "Pet",
                newName: "IX_Pet_OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_FounderId1",
                table: "Pet",
                newName: "IX_Pet_FounderId1");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Pet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FlyingSpeedPerKm",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WingsSizeInCentimeters",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ClimbsOnTrees",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HatesMouses",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HatesCats",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFrendyToPeople",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pet_PetId",
                table: "Comments",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_AspNetUsers_FounderId1",
                table: "Pet",
                column: "FounderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_AspNetUsers_OwnerId1",
                table: "Pet",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
