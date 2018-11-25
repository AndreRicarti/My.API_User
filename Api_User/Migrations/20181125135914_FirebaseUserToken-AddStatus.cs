using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_User.Migrations
{
    public partial class FirebaseUserTokenAddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "FirebaseUserTokens",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FirebaseUserTokens");
        }
    }
}
