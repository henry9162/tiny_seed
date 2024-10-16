using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricTableRelationss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FabricCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FabricCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabrics_FabricCategories_FabricCategoryId",
                        column: x => x.FabricCategoryId,
                        principalTable: "FabricCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomRequestFabrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    FabricId = table.Column<int>(type: "int", nullable: false),
                    CustomRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRequestFabrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomRequestFabrics_CustomRequests_CustomRequestId",
                        column: x => x.CustomRequestId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomRequestFabrics_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FabricImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FabricImages_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestFabrics_CustomRequestId",
                table: "CustomRequestFabrics",
                column: "CustomRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestFabrics_FabricId",
                table: "CustomRequestFabrics",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricImages_FabricId",
                table: "FabricImages",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_FabricCategoryId",
                table: "Fabrics",
                column: "FabricCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomRequestFabrics");

            migrationBuilder.DropTable(
                name: "FabricImages");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "FabricCategories");
        }
    }
}
