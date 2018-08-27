using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_User.Migrations
{
    public partial class AlterUserEmail_AddReview_PersonalDancer_Style_PersonsalDancerStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "PersonalDancer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDancer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDancer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonalDancerId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_PersonalDancer_PersonalDancerId",
                        column: x => x.PersonalDancerId,
                        principalTable: "PersonalDancer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDanceStyle",
                columns: table => new
                {
                    PersonalDancerId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDanceStyle", x => new { x.PersonalDancerId, x.StyleId });
                    table.ForeignKey(
                        name: "FK_PersonalDanceStyle_PersonalDancer_PersonalDancerId",
                        column: x => x.PersonalDancerId,
                        principalTable: "PersonalDancer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalDanceStyle_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDancer_UserId",
                table: "PersonalDancer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDanceStyle_StyleId",
                table: "PersonalDanceStyle",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PersonalDancerId",
                table: "Review",
                column: "PersonalDancerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalDanceStyle");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "PersonalDancer");

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
