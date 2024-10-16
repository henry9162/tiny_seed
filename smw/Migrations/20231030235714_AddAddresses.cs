using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_local_governments_states_stateid",
                table: "local_governments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_states",
                table: "states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_local_governments",
                table: "local_governments");

            migrationBuilder.DropColumn(
                name: "state_id",
                table: "local_governments");

            migrationBuilder.DropColumn(
                name: "email_confirmation_token",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "states",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "local_governments",
                newName: "Local_Governments");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "States",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "States",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "stateid",
                table: "Local_Governments",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Local_Governments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Local_Governments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_local_governments_stateid",
                table: "Local_Governments",
                newName: "IX_Local_Governments_StateId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AspNetUsers",
                newName: "PasswordResetToken");

            migrationBuilder.RenameColumn(
                name: "password_reset_token",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "password_reset_expiry",
                table: "AspNetUsers",
                newName: "PasswordResetExpiry");

            migrationBuilder.RenameColumn(
                name: "password_reset_at",
                table: "AspNetUsers",
                newName: "PasswordResetAt");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "AspNetUsers",
                newName: "EmailConfirmationToken");

            migrationBuilder.RenameColumn(
                name: "email_confirmed_at",
                table: "AspNetUsers",
                newName: "EmailConfirmedAt");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Local_Governments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local_Governments",
                table: "Local_Governments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    LocalGovernmentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_addresses_Local_Governments_LocalGovernmentId",
                        column: x => x.LocalGovernmentId,
                        principalTable: "Local_Governments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_addresses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_ApplicationUserId",
                table: "addresses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_LocalGovernmentId",
                table: "addresses",
                column: "LocalGovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_StateId",
                table: "addresses",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Governments_States_StateId",
                table: "Local_Governments",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Governments_States_StateId",
                table: "Local_Governments");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local_Governments",
                table: "Local_Governments");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "states");

            migrationBuilder.RenameTable(
                name: "Local_Governments",
                newName: "local_governments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "states",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "states",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "local_governments",
                newName: "stateid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "local_governments",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "local_governments",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Local_Governments_StateId",
                table: "local_governments",
                newName: "IX_local_governments_stateid");

            migrationBuilder.RenameColumn(
                name: "PasswordResetToken",
                table: "AspNetUsers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordResetExpiry",
                table: "AspNetUsers",
                newName: "password_reset_expiry");

            migrationBuilder.RenameColumn(
                name: "PasswordResetAt",
                table: "AspNetUsers",
                newName: "password_reset_at");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "password_reset_token");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmedAt",
                table: "AspNetUsers",
                newName: "email_confirmed_at");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmationToken",
                table: "AspNetUsers",
                newName: "first_name");

            migrationBuilder.AlterColumn<int>(
                name: "stateid",
                table: "local_governments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "state_id",
                table: "local_governments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email_confirmation_token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_states",
                table: "states",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_local_governments",
                table: "local_governments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_local_governments_states_stateid",
                table: "local_governments",
                column: "stateid",
                principalTable: "states",
                principalColumn: "id");
        }
    }
}
