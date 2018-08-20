using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftUniClone.Data.Migrations
{
    public partial class Initial44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstance_Course_CourseId",
                table: "CourseInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstance_AspNetUsers_LectorId",
                table: "CourseInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsInCourses_CourseInstance_CourseId",
                table: "StudentsInCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsInCourses",
                table: "StudentsInCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentsInCourses_CourseId",
                table: "StudentsInCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstance",
                table: "CourseInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "CourseInstance",
                newName: "CoursesInstances");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstance_LectorId",
                table: "CoursesInstances",
                newName: "IX_CoursesInstances_LectorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstance_CourseId",
                table: "CoursesInstances",
                newName: "IX_CoursesInstances_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentsInCourses",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsInCourses",
                table: "StudentsInCourses",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursesInstances",
                table: "CoursesInstances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LectureHall = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_CoursesInstances_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LectureId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: true),
                    ResourseUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resourses_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resourses_ResourseTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ResourseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Resourses_LectureId",
                table: "Resourses",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Resourses_TypeId",
                table: "Resourses",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesInstances_Courses_CourseId",
                table: "CoursesInstances",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesInstances_AspNetUsers_LectorId",
                table: "CoursesInstances",
                column: "LectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsInCourses_CoursesInstances_CourseId",
                table: "StudentsInCourses",
                column: "CourseId",
                principalTable: "CoursesInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesInstances_Courses_CourseId",
                table: "CoursesInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesInstances_AspNetUsers_LectorId",
                table: "CoursesInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsInCourses_CoursesInstances_CourseId",
                table: "StudentsInCourses");

            migrationBuilder.DropTable(
                name: "Resourses");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "ResourseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsInCourses",
                table: "StudentsInCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursesInstances",
                table: "CoursesInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "CoursesInstances",
                newName: "CourseInstance");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_CoursesInstances_LectorId",
                table: "CourseInstance",
                newName: "IX_CourseInstance_LectorId");

            migrationBuilder.RenameIndex(
                name: "IX_CoursesInstances_CourseId",
                table: "CourseInstance",
                newName: "IX_CourseInstance_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentsInCourses",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsInCourses",
                table: "StudentsInCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstance",
                table: "CourseInstance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsInCourses_CourseId",
                table: "StudentsInCourses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstance_Course_CourseId",
                table: "CourseInstance",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstance_AspNetUsers_LectorId",
                table: "CourseInstance",
                column: "LectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsInCourses_CourseInstance_CourseId",
                table: "StudentsInCourses",
                column: "CourseId",
                principalTable: "CourseInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
