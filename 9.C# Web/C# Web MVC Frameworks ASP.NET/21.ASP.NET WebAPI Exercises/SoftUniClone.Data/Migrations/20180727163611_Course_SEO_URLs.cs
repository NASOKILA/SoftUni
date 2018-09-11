using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftUniClone.Data.Migrations
{
    public partial class Course_SEO_URLs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "CourseInstances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "CourseInstances");
        }
    }
}
