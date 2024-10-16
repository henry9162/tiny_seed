using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStyleCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "StyleCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "StyleCategories");
        }
    }
}
