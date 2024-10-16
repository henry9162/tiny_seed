using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_FabricImage_Fabrics_FabricId",
            //     table: "FabricImage");

            migrationBuilder.DropForeignKey(
                name: "FK_StyleImage_Styles_StyleId",
                table: "StyleImage");

            // migrationBuilder.DropTable(
            //     name: "CustomRequestCustomRequestFabric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleImage",
                table: "StyleImage");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_FabricImage",
            //     table: "FabricImage");

            migrationBuilder.RenameTable(
                name: "StyleImage",
                newName: "StyleImages");

            // migrationBuilder.RenameTable(
            //     name: "FabricImage",
            //     newName: "FabricImages");

            migrationBuilder.RenameIndex(
                name: "IX_StyleImage_StyleId",
                table: "StyleImages",
                newName: "IX_StyleImages_StyleId");

            // migrationBuilder.RenameIndex(
            //     name: "IX_FabricImage_FabricId",
            //     table: "FabricImages",
            //     newName: "IX_FabricImages_FabricId");

            // migrationBuilder.AddColumn<int>(
            //     name: "CustomRequestId",
            //     table: "CustomRequestFabrics",
            //     type: "int",
            //     nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleImages",
                table: "StyleImages",
                column: "Id");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_FabricImages",
            //     table: "FabricImages",
            //     column: "Id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_CustomRequestFabrics_CustomRequestId",
            //     table: "CustomRequestFabrics",
            //     column: "CustomRequestId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_CustomRequestFabrics_CustomRequests_CustomRequestId",
            //     table: "CustomRequestFabrics",
            //     column: "CustomRequestId",
            //     principalTable: "CustomRequests",
            //     principalColumn: "Id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_FabricImages_Fabrics_FabricId",
            //     table: "FabricImages",
            //     column: "FabricId",
            //     principalTable: "Fabrics",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StyleImages_Styles_StyleId",
                table: "StyleImages",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequestFabrics_CustomRequests_CustomRequestId",
                table: "CustomRequestFabrics");

            migrationBuilder.DropForeignKey(
                name: "FK_FabricImages_Fabrics_FabricId",
                table: "FabricImages");

            migrationBuilder.DropForeignKey(
                name: "FK_StyleImages_Styles_StyleId",
                table: "StyleImages");

            migrationBuilder.DropIndex(
                name: "IX_CustomRequestFabrics_CustomRequestId",
                table: "CustomRequestFabrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleImages",
                table: "StyleImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FabricImages",
                table: "FabricImages");

            migrationBuilder.DropColumn(
                name: "CustomRequestId",
                table: "CustomRequestFabrics");

            migrationBuilder.RenameTable(
                name: "StyleImages",
                newName: "StyleImage");

            migrationBuilder.RenameTable(
                name: "FabricImages",
                newName: "FabricImage");

            migrationBuilder.RenameIndex(
                name: "IX_StyleImages_StyleId",
                table: "StyleImage",
                newName: "IX_StyleImage_StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_FabricImages_FabricId",
                table: "FabricImage",
                newName: "IX_FabricImage_FabricId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleImage",
                table: "StyleImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FabricImage",
                table: "FabricImage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomRequestCustomRequestFabric",
                columns: table => new
                {
                    CustomRequestFabricsId = table.Column<int>(type: "int", nullable: false),
                    CustomRequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRequestCustomRequestFabric", x => new { x.CustomRequestFabricsId, x.CustomRequestsId });
                    table.ForeignKey(
                        name: "FK_CustomRequestCustomRequestFabric_CustomRequestFabrics_CustomRequestFabricsId",
                        column: x => x.CustomRequestFabricsId,
                        principalTable: "CustomRequestFabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomRequestCustomRequestFabric_CustomRequests_CustomRequestsId",
                        column: x => x.CustomRequestsId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestCustomRequestFabric_CustomRequestsId",
                table: "CustomRequestCustomRequestFabric",
                column: "CustomRequestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FabricImage_Fabrics_FabricId",
                table: "FabricImage",
                column: "FabricId",
                principalTable: "Fabrics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StyleImage_Styles_StyleId",
                table: "StyleImage",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
