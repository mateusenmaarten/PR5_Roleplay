using Microsoft.EntityFrameworkCore.Migrations;

namespace Roleplay.Data.Migrations
{
    public partial class seedcharacterclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "PR5",
                table: "CharacterClass",
                columns: new[] { "CharacterClassID", "CharacterClassDescription", "CharacterClassIcon", "CharacterClassName" },
                values: new object[,]
                {
                    { 1, "Big, strong and reckless", "fas fa-dumbbell", "Barbarian" },
                    { 2, "Melodic and charismatic to the core", "fas fa-guitar", "Bard" },
                    { 3, "Healing wonder", "fas fa-plus-square", "Cleric" },
                    { 4, "Weapons Master", "fas fa-fist-raised", "Fighter" },
                    { 5, "religious with a punch", "fas fa-praying-hands", "Monk" },
                    { 6, "There can be only one divine, mine", "fas fa-jedi", "Paladin" },
                    { 7, "Expert marksman", "fas fa-bullseye", "Ranger" },
                    { 8, "In tune with nature and it's animals", "fas fa-paw", "Druid" },
                    { 9, "Sneaky thieving raskal", "fas fa-user-ninja", "Rogue" },
                    { 10, "Uncontrollable power at it's fingertips", "fas fa-hand-sparkles", "Sorcerer" },
                    { 11, "Spelcaster that can keep it's cool", "fas fa-hat-wizard", "Wizard" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "PR5",
                table: "CharacterClass",
                keyColumn: "CharacterClassID",
                keyValue: 11);
        }
    }
}
