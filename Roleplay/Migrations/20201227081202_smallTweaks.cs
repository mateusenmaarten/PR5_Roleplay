using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class smallTweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGameMaster",
                schema: "PR5",
                table: "AdventurePlayer");

            migrationBuilder.AddColumn<string>(
                name: "SessionGamemaster",
                schema: "PR5",
                table: "Session",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionGamemaster",
                schema: "PR5",
                table: "Session");

            migrationBuilder.AddColumn<bool>(
                name: "isGameMaster",
                schema: "PR5",
                table: "AdventurePlayer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
