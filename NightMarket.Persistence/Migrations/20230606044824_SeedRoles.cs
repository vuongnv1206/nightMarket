using Microsoft.EntityFrameworkCore.Migrations;

namespace NightMarket.Persistence.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8add118f-9625-4438-911d-ccd31e1cb43d", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63d946c6-b99f-4731-9ae4-13e642d728de", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4f5116c-53e5-492f-842c-dc4df759e469", "3", "HR", "HR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "63d946c6-b99f-4731-9ae4-13e642d728de");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8add118f-9625-4438-911d-ccd31e1cb43d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f4f5116c-53e5-492f-842c-dc4df759e469");
        }
    }
}
