using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class localDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventurePlayer",
                schema: "PR5");

            migrationBuilder.AddColumn<int>(
                name: "CharacterID",
                schema: "PR5",
                table: "SessionPlayer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SessionGamemaster",
                schema: "PR5",
                table: "Session",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                schema: "PR5",
                table: "Session",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FavouriteWeapon",
                schema: "PR5",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                schema: "PR5",
                table: "Adventure",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterID",
                schema: "PR5",
                table: "SessionPlayer");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                schema: "PR5",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                schema: "PR5",
                table: "Adventure");

            migrationBuilder.AlterColumn<string>(
                name: "SessionGamemaster",
                schema: "PR5",
                table: "Session",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FavouriteWeapon",
                schema: "PR5",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "AdventurePlayer",
                schema: "PR5",
                columns: table => new
                {
                    AdventurePlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureID = table.Column<int>(type: "int", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventurePlayer", x => x.AdventurePlayerID);
                    table.ForeignKey(
                        name: "FK_AdventurePlayer_Adventure_AdventureID",
                        column: x => x.AdventureID,
                        principalSchema: "PR5",
                        principalTable: "Adventure",
                        principalColumn: "AdventureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdventurePlayer_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalSchema: "PR5",
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventurePlayer_AdventureID",
                schema: "PR5",
                table: "AdventurePlayer",
                column: "AdventureID");

            migrationBuilder.CreateIndex(
                name: "IX_AdventurePlayer_PlayerID",
                schema: "PR5",
                table: "AdventurePlayer",
                column: "PlayerID");
        }
    }
}
