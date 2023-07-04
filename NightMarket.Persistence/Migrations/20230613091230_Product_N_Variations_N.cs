using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightMarket.Persistence.Migrations
{
    public partial class Product_N_Variations_N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variations_Categories_CategoryId",
                table: "Variations");

            migrationBuilder.DropIndex(
                name: "IX_Variations_CategoryId",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Variations");

            migrationBuilder.CreateTable(
                name: "ProductVariantions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VariationId = table.Column<int>(type: "int", nullable: false),
                    VariationsId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariantions_Variations_VariationsId",
                        column: x => x.VariationsId,
                        principalTable: "Variations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantions_ProductId",
                table: "ProductVariantions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantions_VariationsId",
                table: "ProductVariantions",
                column: "VariationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariantions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Variations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Variations_CategoryId",
                table: "Variations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_Categories_CategoryId",
                table: "Variations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
