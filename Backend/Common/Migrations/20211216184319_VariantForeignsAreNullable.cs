using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class VariantForeignsAreNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductColors_ColorId",
                table: "ProductVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductDimensions_DimensionId",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "ProductVariants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "ProductVariants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductColors_ColorId",
                table: "ProductVariants",
                column: "ColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductDimensions_DimensionId",
                table: "ProductVariants",
                column: "DimensionId",
                principalTable: "ProductDimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductColors_ColorId",
                table: "ProductVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductDimensions_DimensionId",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "ProductVariants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "ProductVariants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductColors_ColorId",
                table: "ProductVariants",
                column: "ColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductDimensions_DimensionId",
                table: "ProductVariants",
                column: "DimensionId",
                principalTable: "ProductDimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
