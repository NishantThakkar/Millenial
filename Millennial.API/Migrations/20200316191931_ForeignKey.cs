using Microsoft.EntityFrameworkCore.Migrations;

namespace Millennial.API.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeLookup_ProdCatId",
                table: "ProductAttributeLookup",
                column: "ProdCatId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_AttributeId",
                table: "ProductAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProdCatId",
                table: "Product",
                column: "ProdCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProdCatId",
                table: "Product",
                column: "ProdCatId",
                principalTable: "ProductCategory",
                principalColumn: "ProdCatId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_ProductAttributeLookup_AttributeId",
                table: "ProductAttribute",
                column: "AttributeId",
                principalTable: "ProductAttributeLookup",
                principalColumn: "AttributeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_Product_ProductId",
                table: "ProductAttribute",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeLookup_ProductCategory_ProdCatId",
                table: "ProductAttributeLookup",
                column: "ProdCatId",
                principalTable: "ProductCategory",
                principalColumn: "ProdCatId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProdCatId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_ProductAttributeLookup_AttributeId",
                table: "ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_Product_ProductId",
                table: "ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeLookup_ProductCategory_ProdCatId",
                table: "ProductAttributeLookup");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeLookup_ProdCatId",
                table: "ProductAttributeLookup");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttribute_AttributeId",
                table: "ProductAttribute");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProdCatId",
                table: "Product");

           

         
        }
    }
}
