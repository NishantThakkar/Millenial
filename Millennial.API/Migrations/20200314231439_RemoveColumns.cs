using Microsoft.EntityFrameworkCore.Migrations;

namespace Millennial.API.Migrations
{
    public partial class RemoveColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeLookup",
                table: "ProductAttributeLookup");

            migrationBuilder.DropColumn(
                name: "ProdCatId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "ProductAttributeLookup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdCatId",
                table: "ProductCategory",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AttributeId",
                table: "ProductAttributeLookup",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "ProdCatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeLookup",
                table: "ProductAttributeLookup",
                column: "AttributeId");
        }
    }
}
