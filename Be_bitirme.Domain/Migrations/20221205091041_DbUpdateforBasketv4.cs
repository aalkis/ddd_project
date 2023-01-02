using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebitirme.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdateforBasketv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIdListString",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Baskets",
                newName: "BasketStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasketStatus",
                table: "Baskets",
                newName: "OrderStatus");

            migrationBuilder.AddColumn<string>(
                name: "ProductIdListString",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
