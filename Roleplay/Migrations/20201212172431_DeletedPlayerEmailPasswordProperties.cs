using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class DeletedPlayerEmailPasswordProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "PR5",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "PR5",
                table: "Player");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "PR5",
                table: "Player",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "PR5",
                table: "Player",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
