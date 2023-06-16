using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightMarket.Persistence.Migrations
{
    public partial class Product_N_Variations_N2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariantions_Variations_VariationsId",
                table: "ProductVariantions");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariantions_VariationsId",
                table: "ProductVariantions");

            migrationBuilder.DropColumn(
                name: "VariationsId",
                table: "ProductVariantions");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantions_VariationId",
                table: "ProductVariantions",
                column: "VariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariantions_Variations_VariationId",
                table: "ProductVariantions",
                column: "VariationId",
                principalTable: "Variations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariantions_Variations_VariationId",
                table: "ProductVariantions");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariantions_VariationId",
                table: "ProductVariantions");

            migrationBuilder.AddColumn<int>(
                name: "VariationsId",
                table: "ProductVariantions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantions_VariationsId",
                table: "ProductVariantions",
                column: "VariationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariantions_Variations_VariationsId",
                table: "ProductVariantions",
                column: "VariationsId",
                principalTable: "Variations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
