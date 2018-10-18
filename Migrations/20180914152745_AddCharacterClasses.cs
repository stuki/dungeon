using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dungeon.Migrations
{
    public partial class AddCharacterClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Advancedmoves",
                "Characters");

            migrationBuilder.RenameColumn(
                "Startingmoves",
                "Characters",
                "Moves");

            migrationBuilder.AddColumn<int>(
                "CharacterClassId",
                "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                "CharacterClasses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    Attributes = table.Column<string>(nullable: true),
                    HPCalc = table.Column<int>(nullable: false),
                    Damage = table.Column<string>(nullable: true),
                    Alignment = table.Column<string>(nullable: true),
                    StartingInventory = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Bonds = table.Column<string>(nullable: true),
                    Startingmoves = table.Column<string>(nullable: true),
                    Advancedmoves = table.Column<string>(nullable: true),
                    SpellList = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_CharacterClasses", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Characters_CharacterClassId",
                "Characters",
                "CharacterClassId");

            migrationBuilder.AddForeignKey(
                "FK_Characters_CharacterClasses_CharacterClassId",
                "Characters",
                "CharacterClassId",
                "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Characters_CharacterClasses_CharacterClassId",
                "Characters");

            migrationBuilder.DropTable(
                "CharacterClasses");

            migrationBuilder.DropIndex(
                "IX_Characters_CharacterClassId",
                "Characters");

            migrationBuilder.DropColumn(
                "CharacterClassId",
                "Characters");

            migrationBuilder.RenameColumn(
                "Moves",
                "Characters",
                "Startingmoves");

            migrationBuilder.AddColumn<string>(
                "Advancedmoves",
                "Characters",
                nullable: true);
        }
    }
}