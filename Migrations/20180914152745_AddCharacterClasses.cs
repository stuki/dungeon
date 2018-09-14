using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dungeon.Migrations
{
    public partial class AddCharacterClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advancedmoves",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Startingmoves",
                table: "Characters",
                newName: "Moves");

            migrationBuilder.AddColumn<int>(
                name: "CharacterClassId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterClassId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterClassId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Moves",
                table: "Characters",
                newName: "Startingmoves");

            migrationBuilder.AddColumn<string>(
                name: "Advancedmoves",
                table: "Characters",
                nullable: true);
        }
    }
}
