using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class AddedFirstEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PK_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    width = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    height = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    depth = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PK_product);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    PK_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.PK_role);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PK_account = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    FkRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PK_account);
                    table.ForeignKey(
                        name: "FK_Accounts_Role_FkRole",
                        column: x => x.FkRole,
                        principalTable: "Role",
                        principalColumn: "PK_role",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FkRole",
                table: "Accounts",
                column: "FkRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProduct");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
