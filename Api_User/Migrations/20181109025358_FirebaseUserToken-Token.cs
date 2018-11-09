using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_User.Migrations
{
    public partial class FirebaseUserTokenToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "FirebaseUserTokens",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "FirebaseUserTokens");
        }
    }
}
