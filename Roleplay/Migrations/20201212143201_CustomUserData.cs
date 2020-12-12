using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                schema: "PR5",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerID",
                schema: "PR5",
                table: "AspNetUsers",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Player_PlayerID",
                schema: "PR5",
                table: "AspNetUsers",
                column: "PlayerID",
                principalSchema: "PR5",
                principalTable: "Player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Player_PlayerID",
                schema: "PR5",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerID",
                schema: "PR5",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                schema: "PR5",
                table: "AspNetUsers");
        }
    }
}
