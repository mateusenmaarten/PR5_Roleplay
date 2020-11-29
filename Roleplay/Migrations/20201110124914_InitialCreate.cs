using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "PR5");

            migrationBuilder.CreateTable(
                name: "Adventure",
                schema: "PR5",
                columns: table => new
                {
                    AdventureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    MainVillain = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventure", x => x.AdventureID);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                schema: "PR5",
                columns: table => new
                {
                    CharacterClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterClassName = table.Column<string>(nullable: true),
                    CharacterClassDescription = table.Column<string>(nullable: true),
                    CharacterClassIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => x.CharacterClassID);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "PR5",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsGameMaster = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "PR5",
                columns: table => new
                {
                    SessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Recap = table.Column<string>(nullable: true),
                    IsPlayed = table.Column<bool>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Session_Adventure_AdventureID",
                        column: x => x.AdventureID,
                        principalSchema: "PR5",
                        principalTable: "Adventure",
                        principalColumn: "AdventureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdventurePlayer",
                schema: "PR5",
                columns: table => new
                {
                    AdventurePlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    isGameMaster = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Character",
                schema: "PR5",
                columns: table => new
                {
                    CharacterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    CharacterName = table.Column<string>(nullable: true),
                    CharacterGender = table.Column<string>(nullable: false),
                    CharacterDescription = table.Column<string>(nullable: true),
                    CharacterAge = table.Column<int>(nullable: false),
                    FavouriteWeapon = table.Column<string>(nullable: true),
                    HomeTown = table.Column<string>(nullable: true),
                    CharacterClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Character_CharacterClass_CharacterClassID",
                        column: x => x.CharacterClassID,
                        principalSchema: "PR5",
                        principalTable: "CharacterClass",
                        principalColumn: "CharacterClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalSchema: "PR5",
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionPlayer",
                schema: "PR5",
                columns: table => new
                {
                    SessionPlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(nullable: false),
                    SessionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPlayer", x => x.SessionPlayerID);
                    table.ForeignKey(
                        name: "FK_SessionPlayer_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalSchema: "PR5",
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionPlayer_Session_SessionID",
                        column: x => x.SessionID,
                        principalSchema: "PR5",
                        principalTable: "Session",
                        principalColumn: "SessionID",
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

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterClassID",
                schema: "PR5",
                table: "Character",
                column: "CharacterClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlayerID",
                schema: "PR5",
                table: "Character",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Session_AdventureID",
                schema: "PR5",
                table: "Session",
                column: "AdventureID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPlayer_PlayerID",
                schema: "PR5",
                table: "SessionPlayer",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPlayer_SessionID",
                schema: "PR5",
                table: "SessionPlayer",
                column: "SessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventurePlayer",
                schema: "PR5");

            migrationBuilder.DropTable(
                name: "Character",
                schema: "PR5");

            migrationBuilder.DropTable(
                name: "SessionPlayer",
                schema: "PR5");

            migrationBuilder.DropTable(
                name: "CharacterClass",
                schema: "PR5");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "PR5");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "PR5");

            migrationBuilder.DropTable(
                name: "Adventure",
                schema: "PR5");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "PR5",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "PR5",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "PR5",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "PR5",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "PR5",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "PR5",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "PR5",
                newName: "AspNetRoleClaims");
        }
    }
}
