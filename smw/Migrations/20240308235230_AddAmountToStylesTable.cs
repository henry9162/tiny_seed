using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddAmountToStylesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Styles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Styles");
        }
    }
}
