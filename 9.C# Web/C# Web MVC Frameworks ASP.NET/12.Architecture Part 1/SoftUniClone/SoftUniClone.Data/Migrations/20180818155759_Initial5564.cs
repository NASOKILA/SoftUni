using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftUniClone.Data.Migrations
{
    public partial class Initial5564 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesInstances_AspNetUsers_LectorId",
                table: "CoursesInstances");

            migrationBuilder.DropIndex(
                name: "IX_CoursesInstances_LectorId",
                table: "CoursesInstances");

            migrationBuilder.AlterColumn<int>(
                name: "LectorId",
                table: "CoursesInstances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LectorId1",
                table: "CoursesInstances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInstances_LectorId1",
                table: "CoursesInstances",
                column: "LectorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesInstances_AspNetUsers_LectorId1",
                table: "CoursesInstances",
                column: "LectorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesInstances_AspNetUsers_LectorId1",
                table: "CoursesInstances");

            migrationBuilder.DropIndex(
                name: "IX_CoursesInstances_LectorId1",
                table: "CoursesInstances");

            migrationBuilder.DropColumn(
                name: "LectorId1",
                table: "CoursesInstances");

            migrationBuilder.AlterColumn<string>(
                name: "LectorId",
                table: "CoursesInstances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInstances_LectorId",
                table: "CoursesInstances",
                column: "LectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesInstances_AspNetUsers_LectorId",
                table: "CoursesInstances",
                column: "LectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
