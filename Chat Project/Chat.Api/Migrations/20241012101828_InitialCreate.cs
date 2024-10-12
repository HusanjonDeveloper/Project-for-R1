using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12a72feb-1a61-48c0-ab30-c4ab032ea1a9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("80b04498-b713-4fea-b804-75ede70a3edb"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEJzV+1Y4vCI8ISwqGH5L9dmY1KQFJE1ynP6DSFj4pjieFsd1ZChVKr4gJujOIw3sNA==", null, "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80b04498-b713-4fea-b804-75ede70a3edb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("12a72feb-1a61-48c0-ab30-c4ab032ea1a9"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEEBLOadvBDyW+Mupvk3QuOKY0aMInc27kbld0BZ96j0loNKFY5vqbOto6nDHX3XMdQ==", null, "admin", "admin" });
        }
    }
}
