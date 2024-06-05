using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeFakeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[] { 1, "category" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width" },
                values: new object[] { 1, 10.00m, 10.00m, "name", 10.00m, 10.00m });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "PK_role", "name" },
                values: new object[] { 1, "name" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "FkRole", "last_name", "phone" },
                values: new object[] { 1, "email@email.pl", "fname", 1, "lname", "000111222" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "PK_role",
                keyValue: 1);
        }
    }
}
