using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebitirme.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdateforBasketv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductIdListString",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIdListString",
                table: "Baskets");
        }
    }
}
