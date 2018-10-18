using Microsoft.EntityFrameworkCore.Migrations;

namespace dungeon.Migrations
{
    public partial class RemoveIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Characters_CharacterClasses_CharacterClassId",
                "Characters");

            migrationBuilder.DropForeignKey(
                "FK_Characters_Sessions_SessionId",
                "Characters");

            migrationBuilder.RenameColumn(
                "Text",
                "Logs",
                "Tag");

            migrationBuilder.RenameColumn(
                "Label",
                "Logs",
                "Message");

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Sessions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "SessionId",
                "Characters",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                "CharacterClassId",
                "Characters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                "FK_Characters_CharacterClasses_CharacterClassId",
                "Characters",
                "CharacterClassId",
                "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Characters_Sessions_SessionId",
                "Characters",
                "SessionId",
                "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Characters_CharacterClasses_CharacterClassId",
                "Characters");

            migrationBuilder.DropForeignKey(
                "FK_Characters_Sessions_SessionId",
                "Characters");

            migrationBuilder.RenameColumn(
                "Tag",
                "Logs",
                "Text");

            migrationBuilder.RenameColumn(
                "Message",
                "Logs",
                "Label");

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Sessions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "SessionId",
                "Characters",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                "CharacterClassId",
                "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Characters_CharacterClasses_CharacterClassId",
                "Characters",
                "CharacterClassId",
                "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Characters_Sessions_SessionId",
                "Characters",
                "SessionId",
                "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}