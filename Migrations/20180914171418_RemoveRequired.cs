using Microsoft.EntityFrameworkCore.Migrations;

namespace dungeon.Migrations
{
    public partial class RemoveRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Logs_Sessions_SessionId",
                "Logs");

            migrationBuilder.AlterColumn<string>(
                "Tag",
                "Logs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "SessionId",
                "Logs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "Message",
                "Logs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Characters",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                "FK_Logs_Sessions_SessionId",
                "Logs",
                "SessionId",
                "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Logs_Sessions_SessionId",
                "Logs");

            migrationBuilder.AlterColumn<string>(
                "Tag",
                "Logs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "SessionId",
                "Logs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Message",
                "Logs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "Characters",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Logs_Sessions_SessionId",
                "Logs",
                "SessionId",
                "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}