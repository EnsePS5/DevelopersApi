using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevelopersApi.Migrations
{
    public partial class InitialMigrationKolos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    IdDeveloper = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Developer_pk", x => x.IdDeveloper);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    IdGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RealeseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeedVrImplement = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Game_pk", x => x.IdGame);
                });

            migrationBuilder.CreateTable(
                name: "Developer_Game",
                columns: table => new
                {
                    IdDeveloper = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DeveloperGame_pk", x => new { x.IdDeveloper, x.IdGame });
                    table.ForeignKey(
                        name: "DeveloperGame_Developer",
                        column: x => x.IdDeveloper,
                        principalTable: "Developer",
                        principalColumn: "IdDeveloper",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "DeveloperGame_Game",
                        column: x => x.IdGame,
                        principalTable: "Game",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "IdDeveloper", "DateOfJoin", "Firstname", "Lastname" },
                values: new object[] { 1, new DateTime(2022, 6, 8, 18, 18, 13, 10, DateTimeKind.Local).AddTicks(826), "James", "Scott" });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "IdDeveloper", "DateOfJoin", "Firstname", "Lastname" },
                values: new object[] { 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kacper", "Godlewski" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "IdGame", "Name", "NeedVrImplement", "RealeseDate" },
                values: new object[] { 1, "The Party Hub", (byte)0, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Developer_Game",
                columns: new[] { "IdDeveloper", "IdGame", "Role" },
                values: new object[] { 2, 1, "Main Developer" });

            migrationBuilder.InsertData(
                table: "Developer_Game",
                columns: new[] { "IdDeveloper", "IdGame", "Role" },
                values: new object[] { 1, 1, "Assistant" });

            migrationBuilder.CreateIndex(
                name: "IX_Developer_Game_IdGame",
                table: "Developer_Game",
                column: "IdGame");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developer_Game");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
