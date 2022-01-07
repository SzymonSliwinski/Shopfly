using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class CreatingDefaultAdminAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRoot",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "IsActive", "IsRoot", "Name", "Password", "Surname" },
                values: new object[] { 1, "admin@shopfly.pl", true, true, "Admin", "d9cf543a5140a41876b6fed780981a1625b48185d73902749e5e4e6b6cc8dba9", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsRoot",
                table: "Employees");
        }
    }
}
