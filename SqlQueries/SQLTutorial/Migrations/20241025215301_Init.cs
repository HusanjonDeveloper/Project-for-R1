using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLTutorial.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "product",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "product",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "product");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
