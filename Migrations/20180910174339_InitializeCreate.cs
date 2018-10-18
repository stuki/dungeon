using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dungeon.Migrations
{
    public partial class InitializeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Players",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Players", x => x.Id); });

            migrationBuilder.CreateTable(
                "Sessions",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DungeonMasterId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Sessions", x => x.Id); });

            migrationBuilder.CreateTable(
                "Characters",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    SessionId = table.Column<string>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Looks = table.Column<string>(nullable: true),
                    Armor = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    XP = table.Column<int>(nullable: false),
                    Hitpoints = table.Column<int>(nullable: false),
                    Damage = table.Column<int>(nullable: false),
                    Alignment = table.Column<string>(nullable: true),
                    Gear = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Bonds = table.Column<string>(nullable: true),
                    Startingmoves = table.Column<string>(nullable: true),
                    Advancedmoves = table.Column<string>(nullable: true),
                    Coin = table.Column<int>(nullable: false),
                    Spells = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        "FK_Characters_Sessions_SessionId",
                        x => x.SessionId,
                        "Sessions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Logs",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<string>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Label = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        "FK_Logs_Sessions_SessionId",
                        x => x.SessionId,
                        "Sessions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PlayerSessions",
                table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    SessionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSessions", x => new {x.PlayerId, x.SessionId});
                    table.ForeignKey(
                        "FK_PlayerSessions_Players_PlayerId",
                        x => x.PlayerId,
                        "Players",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PlayerSessions_Sessions_SessionId",
                        x => x.SessionId,
                        "Sessions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Characters_SessionId",
                "Characters",
                "SessionId");

            migrationBuilder.CreateIndex(
                "IX_Logs_SessionId",
                "Logs",
                "SessionId");

            migrationBuilder.CreateIndex(
                "IX_PlayerSessions_SessionId",
                "PlayerSessions",
                "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Characters");

            migrationBuilder.DropTable(
                "Logs");

            migrationBuilder.DropTable(
                "PlayerSessions");

            migrationBuilder.DropTable(
                "Players");

            migrationBuilder.DropTable(
                "Sessions");
        }
    }
}