using Microsoft.EntityFrameworkCore.Migrations;

namespace Millennial.API.Migrations
{
    public partial class TableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeLookups",
                table: "ProductAttributeLookups");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductAttributes",
                newName: "ProductAttribute");

            migrationBuilder.RenameTable(
                name: "ProductAttributeLookups",
                newName: "ProductAttributeLookup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "ProdCatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute",
                columns: new[] { "ProductId", "AttributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeLookup",
                table: "ProductAttributeLookup",
                column: "AttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeLookup",
                table: "ProductAttributeLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductAttributeLookup",
                newName: "ProductAttributeLookups");

            migrationBuilder.RenameTable(
                name: "ProductAttribute",
                newName: "ProductAttributes");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "ProdCatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeLookups",
                table: "ProductAttributeLookups",
                column: "AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes",
                columns: new[] { "ProductId", "AttributeId", "AttributeValue" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");
        }
    }
}
