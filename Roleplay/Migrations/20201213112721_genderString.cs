using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class genderString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CharacterGender",
                schema: "PR5",
                table: "Character",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CharacterGender",
                schema: "PR5",
                table: "Character",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
