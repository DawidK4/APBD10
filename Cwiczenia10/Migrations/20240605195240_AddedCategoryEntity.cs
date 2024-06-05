using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PK_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryPkCategory = table.Column<int>(type: "int", nullable: true),
                    ProductPkProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PK_category);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryPkCategory",
                        column: x => x.CategoryPkCategory,
                        principalTable: "Categories",
                        principalColumn: "PK_category");
                    table.ForeignKey(
                        name: "FK_Categories_Products_ProductPkProduct",
                        column: x => x.ProductPkProduct,
                        principalTable: "Products",
                        principalColumn: "PK_product");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryPkCategory",
                table: "Categories",
                column: "CategoryPkCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductPkProduct",
                table: "Categories",
                column: "ProductPkProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
