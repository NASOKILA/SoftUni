using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyPet.Data.Migrations
{
    public partial class MessgesLikesDisabledPropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LikeDisabled",
                table: "Messages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeDisabled",
                table: "Messages");
        }
    }
}
