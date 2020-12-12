using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class customPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "PR5",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_UserID",
                schema: "PR5",
                table: "Player",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_AspNetUsers_UserID",
                schema: "PR5",
                table: "Player",
                column: "UserID",
                principalSchema: "PR5",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_AspNetUsers_UserID",
                schema: "PR5",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_UserID",
                schema: "PR5",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "PR5",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                schema: "PR5",
                table: "AspNetUsers",
                type: "int",
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
    }
}
