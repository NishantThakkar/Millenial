using Microsoft.EntityFrameworkCore.Migrations;

namespace Millennial.API.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "ProdCatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeLookup",
                table: "ProductAttributeLookup",
                column: "AttributeId");

            migrationBuilder.InsertData(
                table: "ProductAttributeLookup",
                columns: new[] { "AttributeId", "AttributeName", "ProdCatId" },
                values: new object[,]
                {
                    { 1, "Color", 1 },
                    { 2, "Make", 1 },
                    { 3, "Model", 1 },
                    { 4, "RAM", 2 },
                    { 5, "Front Camera", 2 },
                    { 6, "Rear Camera", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "ProdCatId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Mobile" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeLookup",
                table: "ProductAttributeLookup");

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookup",
                keyColumn: "AttributeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookup",
                keyColumn: "AttributeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookup",
                keyColumn: "AttributeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookup",
                keyColumn: "AttributeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookup",
                keyColumn: "AttributeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookup",
                keyColumn: "AttributeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "ProdCatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "ProdCatId",
                keyValue: 2);
        }
    }
}
