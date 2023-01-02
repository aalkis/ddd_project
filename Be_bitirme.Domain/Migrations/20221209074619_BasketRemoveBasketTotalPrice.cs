using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebitirme.Domain.Migrations
{
    /// <inheritdoc />
    public partial class BasketRemoveBasketTotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BasketTotalPrice",
                table: "Baskets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BasketTotalPrice",
                table: "Baskets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId1",
                table: "Categories",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId1",
                table: "Categories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
