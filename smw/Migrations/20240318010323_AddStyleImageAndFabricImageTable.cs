using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddStyleImageAndFabricImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName1",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImageName2",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImageName3",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImagePath1",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImagePath2",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImagePath3",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImageName1",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ImageName2",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ImageName3",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ImagePath1",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ImagePath2",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ImagePath3",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ImageName1",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "ImageName2",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "ImageName3",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "ImagePath1",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "ImagePath2",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "ImagePath3",
                table: "CustomRequests");

            migrationBuilder.CreateTable(
                name: "CustomRequestImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomRequestId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRequestImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomRequestImage_CustomRequests_CustomRequestId",
                        column: x => x.CustomRequestId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FabricImage",
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
                    table.PrimaryKey("PK_FabricImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FabricImage_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StyleImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StyleImage_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestImage_CustomRequestId",
                table: "CustomRequestImage",
                column: "CustomRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricImage_FabricId",
                table: "FabricImage",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_StyleImage_StyleId",
                table: "StyleImage",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomRequestImage");

            migrationBuilder.DropTable(
                name: "FabricImage");

            migrationBuilder.DropTable(
                name: "StyleImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageName1",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName2",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName3",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath1",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath2",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath3",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName1",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName2",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName3",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath1",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath2",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath3",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName1",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName2",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName3",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath1",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath2",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath3",
                table: "CustomRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
