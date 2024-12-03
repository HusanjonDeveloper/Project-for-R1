using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Api.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4c950807-5d76-4ce1-905b-fb7f667861d3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("4c2fa7de-cf82-4ff9-a3c6-a799c0b5d06c"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEHxBzn1ZJ6JSh82JF5s2oGKdlDSiWvOH+xexW7DV9An+AZ2gK0eqIHRZwcWkU0sppw==", null, "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4c2fa7de-cf82-4ff9-a3c6-a799c0b5d06c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("4c950807-5d76-4ce1-905b-fb7f667861d3"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEAhHfbJg4CO2j19gh4UXogG55ueMqmk/JQbMJQdPZzzVt2LRFpU+otbVdgzveluxaw==", null, "admin", "admin" });
        }
    }
}
