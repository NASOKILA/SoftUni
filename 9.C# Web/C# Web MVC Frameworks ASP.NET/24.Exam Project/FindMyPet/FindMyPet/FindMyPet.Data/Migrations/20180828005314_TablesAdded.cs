using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMyPet.Data.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(nullable: false),
                    SenderId1 = table.Column<string>(nullable: true),
                    ReceverId = table.Column<int>(nullable: false),
                    ReceverId1 = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceverId1",
                        column: x => x.ReceverId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId1",
                        column: x => x.SenderId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true),
                    FounderId = table.Column<int>(nullable: false),
                    FounderId1 = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    LocationLost = table.Column<string>(nullable: true),
                    TimeLost = table.Column<DateTime>(nullable: false),
                    TimeFound = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    WingsSizeInCentimeters = table.Column<double>(nullable: true),
                    FlyingSpeedPerKm = table.Column<double>(nullable: true),
                    ClimbsOnTrees = table.Column<bool>(nullable: true),
                    HatesMouses = table.Column<bool>(nullable: true),
                    HatesCats = table.Column<bool>(nullable: true),
                    IsFrendyToPeople = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_AspNetUsers_FounderId1",
                        column: x => x.FounderId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pet_AspNetUsers_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: false),
                    CreatorId1 = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CreatorId1",
                        column: x => x.CreatorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatorId1",
                table: "Comments",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PetId",
                table: "Comments",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceverId1",
                table: "Messages",
                column: "ReceverId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId1",
                table: "Messages",
                column: "SenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_FounderId1",
                table: "Pet",
                column: "FounderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OwnerId1",
                table: "Pet",
                column: "OwnerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Pet");
        }
    }
}
