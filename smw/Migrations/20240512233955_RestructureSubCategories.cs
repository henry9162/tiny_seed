using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class RestructureSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                table: "Fabrics");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_StyleCategories_StyleCategoryId",
                table: "Styles");

            migrationBuilder.DropTable(
                name: "FabricFabricSubCategory");

            migrationBuilder.DropTable(
                name: "StyleStyleSubCategory");

            migrationBuilder.RenameColumn(
                name: "StyleCategoryId",
                table: "Styles",
                newName: "StyleSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Styles_StyleCategoryId",
                table: "Styles",
                newName: "IX_Styles_StyleSubCategoryId");

            migrationBuilder.RenameColumn(
                name: "FabricCategoryId",
                table: "Fabrics",
                newName: "FabricSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Fabrics_FabricCategoryId",
                table: "Fabrics",
                newName: "IX_Fabrics_FabricSubCategoryId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "StyleSubCategories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StyleAttributes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FabricSubCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FabricSubCategories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FabricCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FabricCategories_Name",
                table: "FabricCategories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrics_FabricSubCategories_FabricSubCategoryId",
                table: "Fabrics",
                column: "FabricSubCategoryId",
                principalTable: "FabricSubCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_StyleSubCategories_StyleSubCategoryId",
                table: "Styles",
                column: "StyleSubCategoryId",
                principalTable: "StyleSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrics_FabricSubCategories_FabricSubCategoryId",
                table: "Fabrics");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_StyleSubCategories_StyleSubCategoryId",
                table: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_FabricCategories_Name",
                table: "FabricCategories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "StyleSubCategories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FabricSubCategories");

            migrationBuilder.RenameColumn(
                name: "StyleSubCategoryId",
                table: "Styles",
                newName: "StyleCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Styles_StyleSubCategoryId",
                table: "Styles",
                newName: "IX_Styles_StyleCategoryId");

            migrationBuilder.RenameColumn(
                name: "FabricSubCategoryId",
                table: "Fabrics",
                newName: "FabricCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Fabrics_FabricSubCategoryId",
                table: "Fabrics",
                newName: "IX_Fabrics_FabricCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StyleAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FabricSubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FabricCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FabricFabricSubCategory",
                columns: table => new
                {
                    FabricSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    FabricsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricFabricSubCategory", x => new { x.FabricSubCategoriesId, x.FabricsId });
                    table.ForeignKey(
                        name: "FK_FabricFabricSubCategory_FabricSubCategories_FabricSubCategoriesId",
                        column: x => x.FabricSubCategoriesId,
                        principalTable: "FabricSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FabricFabricSubCategory_Fabrics_FabricsId",
                        column: x => x.FabricsId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StyleStyleSubCategory",
                columns: table => new
                {
                    StyleSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    StylesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleStyleSubCategory", x => new { x.StyleSubCategoriesId, x.StylesId });
                    table.ForeignKey(
                        name: "FK_StyleStyleSubCategory_StyleSubCategories_StyleSubCategoriesId",
                        column: x => x.StyleSubCategoriesId,
                        principalTable: "StyleSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StyleStyleSubCategory_Styles_StylesId",
                        column: x => x.StylesId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FabricFabricSubCategory_FabricsId",
                table: "FabricFabricSubCategory",
                column: "FabricsId");

            migrationBuilder.CreateIndex(
                name: "IX_StyleStyleSubCategory_StylesId",
                table: "StyleStyleSubCategory",
                column: "StylesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                table: "Fabrics",
                column: "FabricCategoryId",
                principalTable: "FabricCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_StyleCategories_StyleCategoryId",
                table: "Styles",
                column: "StyleCategoryId",
                principalTable: "StyleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
