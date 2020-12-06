using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class addedrequiredfieldstotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassID",
                schema: "PR5",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ClassID",
                schema: "PR5",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "PR5",
                table: "Player",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "PR5",
                table: "Player",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "PR5",
                table: "Player",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterClassName",
                schema: "PR5",
                table: "CharacterClass",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterClassIcon",
                schema: "PR5",
                table: "CharacterClass",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterClassDescription",
                schema: "PR5",
                table: "CharacterClass",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterName",
                schema: "PR5",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterDescription",
                schema: "PR5",
                table: "Character",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterClassID",
                schema: "PR5",
                table: "Character",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "PR5",
                table: "Adventure",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                schema: "PR5",
                table: "Adventure",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                schema: "PR5",
                table: "Adventure",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassID",
                schema: "PR5",
                table: "Character",
                column: "CharacterClassID",
                principalSchema: "PR5",
                principalTable: "CharacterClass",
                principalColumn: "CharacterClassID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassID",
                schema: "PR5",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "PR5",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "PR5",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "PR5",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CharacterClassName",
                schema: "PR5",
                table: "CharacterClass",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CharacterClassIcon",
                schema: "PR5",
                table: "CharacterClass",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CharacterClassDescription",
                schema: "PR5",
                table: "CharacterClass",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CharacterName",
                schema: "PR5",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CharacterDescription",
                schema: "PR5",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CharacterClassID",
                schema: "PR5",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                schema: "PR5",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "PR5",
                table: "Adventure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                schema: "PR5",
                table: "Adventure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                schema: "PR5",
                table: "Adventure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Character_CharacterClass_CharacterClassID",
                schema: "PR5",
                table: "Character",
                column: "CharacterClassID",
                principalSchema: "PR5",
                principalTable: "CharacterClass",
                principalColumn: "CharacterClassID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
