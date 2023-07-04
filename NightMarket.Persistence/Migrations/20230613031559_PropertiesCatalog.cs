using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightMarket.Persistence.Migrations
{
    public partial class PropertiesCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ProductItems");

            migrationBuilder.AddColumn<double>(
                name: "CompareAtPrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);



			migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "CompareAtPrice",
                table: "ProductItems",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromoImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompareAtPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");



			migrationBuilder.DropColumn(
                name: "CompareAtPrice",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "PromoImage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
