using Microsoft.EntityFrameworkCore.Migrations;

namespace Millennial.API.Migrations
{
    public partial class RemoveColumnsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttributeId",
                table: "ProductAttributeLookup",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
