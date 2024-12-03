using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Api.Migrations
{
    /// <inheritdoc />
    public partial class AllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4c2fa7de-cf82-4ff9-a3c6-a799c0b5d06c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("d5bd98bd-a612-48dd-9f09-63fad98f3302"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEPqyDlI1L9zVSjwYZUz1/N3OnrYCssBuf0pkXBMPmd9GkCOOTZjw2nm4iGO1Ap3jYw==", null, "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5bd98bd-a612-48dd-9f09-63fad98f3302"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Bio", "FirstName", "Gender", "LastName", "PasswordHash", "PhotoData", "Role", "Username" },
                values: new object[] { new Guid("4c2fa7de-cf82-4ff9-a3c6-a799c0b5d06c"), null, null, "Admin", "male", "Admin", "AQAAAAIAAYagAAAAEHxBzn1ZJ6JSh82JF5s2oGKdlDSiWvOH+xexW7DV9An+AZ2gK0eqIHRZwcWkU0sppw==", null, "admin", "admin" });
        }
    }
}
