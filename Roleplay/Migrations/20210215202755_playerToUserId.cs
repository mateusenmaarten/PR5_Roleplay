using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class playerToUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerID",
                schema: "PR5",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                schema: "PR5",
                table: "Adventure");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Session",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Character",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Adventure",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                schema: "PR5",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                schema: "PR5",
                table: "Adventure",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
