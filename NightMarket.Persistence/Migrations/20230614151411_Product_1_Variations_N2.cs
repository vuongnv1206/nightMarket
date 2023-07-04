using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightMarket.Persistence.Migrations
{
    public partial class Product_1_Variations_N2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Variations_ProductId",
                table: "Variations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_Products_ProductId",
                table: "Variations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variations_Products_ProductId",
                table: "Variations");

            migrationBuilder.DropIndex(
                name: "IX_Variations_ProductId",
                table: "Variations");
        }
    }
}
