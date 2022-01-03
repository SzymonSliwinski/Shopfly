using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class UpdatedShopModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfilesPrivileges");

            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToApi",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToCharts",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToCustomers",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToEmployees",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToImports",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToOrders",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToProducts",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAccessToSettings",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAccessToApi",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToCharts",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToCustomers",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToEmployees",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToImports",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToOrders",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToProducts",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "HasAccessToSettings",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilesPrivileges",
                columns: table => new
                {
                    PrivilegeId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilesPrivileges", x => new { x.PrivilegeId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_ProfilesPrivileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfilesPrivileges_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Privileges_Name",
                table: "Privileges",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesPrivileges_ProfileId",
                table: "ProfilesPrivileges",
                column: "ProfileId");
        }
    }
}
