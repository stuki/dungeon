using Microsoft.EntityFrameworkCore.Migrations;

namespace dungeon.Migrations
{
    public partial class RemoveIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Logs",
                newName: "Tag");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Logs",
                newName: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sessions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CharacterClassId",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "Logs",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Logs",
                newName: "Label");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sessions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterClassId",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Sessions_SessionId",
                table: "Characters",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
