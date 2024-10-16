using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordResetToken",
                table: "AspNetUsers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "passwordResetExpiry",
                table: "AspNetUsers",
                newName: "password_reset_expiry");

            migrationBuilder.RenameColumn(
                name: "passwordResetAt",
                table: "AspNetUsers",
                newName: "password_reset_at");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "AspNetUsers",
                newName: "password_reset_token");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "AspNetUsers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "emailConfirmedAt",
                table: "AspNetUsers",
                newName: "email_confirmed_at");

            migrationBuilder.RenameColumn(
                name: "emailConfirmationToken",
                table: "AspNetUsers",
                newName: "first_name");

            migrationBuilder.AddColumn<string>(
                name: "email_confirmation_token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_confirmation_token",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AspNetUsers",
                newName: "passwordResetToken");

            migrationBuilder.RenameColumn(
                name: "password_reset_token",
                table: "AspNetUsers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "password_reset_expiry",
                table: "AspNetUsers",
                newName: "passwordResetExpiry");

            migrationBuilder.RenameColumn(
                name: "password_reset_at",
                table: "AspNetUsers",
                newName: "passwordResetAt");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "AspNetUsers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "AspNetUsers",
                newName: "emailConfirmationToken");

            migrationBuilder.RenameColumn(
                name: "email_confirmed_at",
                table: "AspNetUsers",
                newName: "emailConfirmedAt");
        }
    }
}
