using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricTableRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequestImage_CustomRequests_CustomRequestId",
                table: "CustomRequestImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomRequestImage",
                table: "CustomRequestImage");

            migrationBuilder.RenameTable(
                name: "CustomRequestImage",
                newName: "CustomRequestImages");

            migrationBuilder.RenameIndex(
                name: "IX_CustomRequestImage_CustomRequestId",
                table: "CustomRequestImages",
                newName: "IX_CustomRequestImages_CustomRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomRequestImages",
                table: "CustomRequestImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRequestImages_CustomRequests_CustomRequestId",
                table: "CustomRequestImages",
                column: "CustomRequestId",
                principalTable: "CustomRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequestImages_CustomRequests_CustomRequestId",
                table: "CustomRequestImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomRequestImages",
                table: "CustomRequestImages");

            migrationBuilder.RenameTable(
                name: "CustomRequestImages",
                newName: "CustomRequestImage");

            migrationBuilder.RenameIndex(
                name: "IX_CustomRequestImages_CustomRequestId",
                table: "CustomRequestImage",
                newName: "IX_CustomRequestImage_CustomRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomRequestImage",
                table: "CustomRequestImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRequestImage_CustomRequests_CustomRequestId",
                table: "CustomRequestImage",
                column: "CustomRequestId",
                principalTable: "CustomRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
