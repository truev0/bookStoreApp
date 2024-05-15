using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class updateSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sales",
                newName: "SaleDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sales",
                newName: "Date");
        }
    }
}
