using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevelopersApi.Migrations
{
    public partial class SqlEndpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Developer",
                keyColumn: "IdDeveloper",
                keyValue: 1,
                column: "DateOfJoin",
                value: new DateTime(2022, 6, 9, 0, 39, 57, 348, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "IdDeveloper", "DateOfJoin", "Firstname", "Lastname" },
                values: new object[] { 3, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maciej", "Wrzosek" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developer",
                keyColumn: "IdDeveloper",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Developer",
                keyColumn: "IdDeveloper",
                keyValue: 1,
                column: "DateOfJoin",
                value: new DateTime(2022, 6, 8, 18, 18, 13, 10, DateTimeKind.Local).AddTicks(826));
        }
    }
}
