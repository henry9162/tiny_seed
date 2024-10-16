using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricAndStyleSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                table: "Fabrics");

            migrationBuilder.AlterColumn<int>(
                name: "FabricCategoryId",
                table: "Fabrics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Colors",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FabricCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "FabricSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FabricCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FabricSubCategories_FabricCategories_FabricCategoryId",
                        column: x => x.FabricCategoryId,
                        principalTable: "FabricCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StyleSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StyleSubCategories_StyleCategories_StyleCategoryId",
                        column: x => x.StyleCategoryId,
                        principalTable: "StyleCategories",
                        principalColumn: "Id");
                });

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
                name: "IX_FabricSubCategories_FabricCategoryId",
                table: "FabricSubCategories",
                column: "FabricCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StyleStyleSubCategory_StylesId",
                table: "StyleStyleSubCategory",
                column: "StylesId");

            migrationBuilder.CreateIndex(
                name: "IX_StyleSubCategories_StyleCategoryId",
                table: "StyleSubCategories",
                column: "StyleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                table: "Fabrics",
                column: "FabricCategoryId",
                principalTable: "FabricCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                table: "Fabrics");

            migrationBuilder.DropTable(
                name: "FabricFabricSubCategory");

            migrationBuilder.DropTable(
                name: "StyleStyleSubCategory");

            migrationBuilder.DropTable(
                name: "FabricSubCategories");

            migrationBuilder.DropTable(
                name: "StyleSubCategories");

            migrationBuilder.AlterColumn<int>(
                name: "FabricCategoryId",
                table: "Fabrics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Colors",
                table: "Fabrics",
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
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                table: "Fabrics",
                column: "FabricCategoryId",
                principalTable: "FabricCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
