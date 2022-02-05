using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class ExtendedSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopAddress",
                table: "ShopSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopEmail",
                table: "ShopSettings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopNip",
                table: "ShopSettings",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopPhone",
                table: "ShopSettings",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopAddress",
                table: "ShopSettings");

            migrationBuilder.DropColumn(
                name: "ShopEmail",
                table: "ShopSettings");

            migrationBuilder.DropColumn(
                name: "ShopNip",
                table: "ShopSettings");

            migrationBuilder.DropColumn(
                name: "ShopPhone",
                table: "ShopSettings");
        }
    }
}
