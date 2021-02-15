using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class changeToUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "PR5",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "PR5",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "PR5",
                table: "Adventure");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "PR5",
                table: "Session",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "PR5",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "PR5",
                table: "Adventure",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "PR5",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "PR5",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "PR5",
                table: "Adventure");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Session",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Adventure",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
