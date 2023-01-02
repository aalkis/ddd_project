using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bebitirme.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdateforProductv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmartUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmartUrl",
                table: "Products");
        }
    }
}
