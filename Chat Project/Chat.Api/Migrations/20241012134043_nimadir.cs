using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Api.Migrations
{
    /// <inheritdoc />
    public partial class nimadir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80b04498-b713-4fea-b804-75ede70a3edb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("4c950807-5d76-4ce1-905b-fb7f667861d3"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEAhHfbJg4CO2j19gh4UXogG55ueMqmk/JQbMJQdPZzzVt2LRFpU+otbVdgzveluxaw==", null, "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4c950807-5d76-4ce1-905b-fb7f667861d3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("80b04498-b713-4fea-b804-75ede70a3edb"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEJzV+1Y4vCI8ISwqGH5L9dmY1KQFJE1ynP6DSFj4pjieFsd1ZChVKr4gJujOIw3sNA==", null, "admin", "admin" });
        }
    }
}
