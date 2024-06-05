using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class AddedMinorFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountProduct",
                columns: table => new
                {
                    AccountsPkAccount = table.Column<int>(type: "int", nullable: false),
                    ProductsPkProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProduct", x => new { x.AccountsPkAccount, x.ProductsPkProduct });
                    table.ForeignKey(
                        name: "FK_AccountProduct_Accounts_AccountsPkAccount",
                        column: x => x.AccountsPkAccount,
                        principalTable: "Accounts",
                        principalColumn: "PK_account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountProduct_Products_ProductsPkProduct",
                        column: x => x.ProductsPkProduct,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountProduct_ProductsPkProduct",
                table: "AccountProduct",
                column: "ProductsPkProduct");
        }
    }
}
