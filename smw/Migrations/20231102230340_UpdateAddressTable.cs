using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_AspNetUsers_ApplicationUserId",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_addresses_Local_Governments_LocalGovernmentId",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_addresses_States_StateId",
                table: "addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Addresses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_StateId",
                table: "Addresses",
                newName: "IX_Addresses_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_LocalGovernmentId",
                table: "Addresses",
                newName: "IX_Addresses_LocalGovernmentId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_ApplicationUserId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Local_Governments_LocalGovernmentId",
                table: "Addresses",
                column: "LocalGovernmentId",
                principalTable: "Local_Governments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Local_Governments_LocalGovernmentId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "addresses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "addresses",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StateId",
                table: "addresses",
                newName: "IX_addresses_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_LocalGovernmentId",
                table: "addresses",
                newName: "IX_addresses_LocalGovernmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "addresses",
                newName: "IX_addresses_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_AspNetUsers_ApplicationUserId",
                table: "addresses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_Local_Governments_LocalGovernmentId",
                table: "addresses",
                column: "LocalGovernmentId",
                principalTable: "Local_Governments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_States_StateId",
                table: "addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
