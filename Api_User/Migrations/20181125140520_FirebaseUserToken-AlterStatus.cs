using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_User.Migrations
{
    public partial class FirebaseUserTokenAlterStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "FirebaseUserTokens",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FirebaseUserTokens",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
