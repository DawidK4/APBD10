using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class FixedLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryPkCategory",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductPkProduct",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryPkCategory",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductPkProduct",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryPkCategory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductPkProduct",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesPkCategory = table.Column<int>(type: "int", nullable: false),
                    ProductsPkProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesPkCategory, x.ProductsPkProduct });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesPkCategory",
                        column: x => x.CategoriesPkCategory,
                        principalTable: "Categories",
                        principalColumn: "PK_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsPkProduct",
                        column: x => x.ProductsPkProduct,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsPkProduct",
                table: "CategoryProduct",
                column: "ProductsPkProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.AddColumn<int>(
                name: "CategoryPkCategory",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductPkProduct",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryPkCategory",
                table: "Categories",
                column: "CategoryPkCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductPkProduct",
                table: "Categories",
                column: "ProductPkProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryPkCategory",
                table: "Categories",
                column: "CategoryPkCategory",
                principalTable: "Categories",
                principalColumn: "PK_category");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductPkProduct",
                table: "Categories",
                column: "ProductPkProduct",
                principalTable: "Products",
                principalColumn: "PK_product");
        }
    }
}
