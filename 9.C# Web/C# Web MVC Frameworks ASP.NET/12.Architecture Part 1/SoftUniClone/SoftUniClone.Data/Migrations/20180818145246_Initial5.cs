using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftUniClone.Data.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentsInCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentsInCourses",
                nullable: false,
                defaultValue: 0);
        }
    }
}
