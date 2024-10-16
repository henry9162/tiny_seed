using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class CustomRequestTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequestFabrics_CustomRequests_CustomRequestId",
                table: "CustomRequestFabrics");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_BillingInformations_BillingInformationId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_ShippingInformations_ShippingInformationId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeCharts_CustomRequests_CustomRequestId",
                table: "SizeCharts");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_CustomRequests_CustomRequestId",
                table: "Styles");

            migrationBuilder.DropTable(
                name: "BillingInformations");

            migrationBuilder.DropTable(
                name: "ShippingInformations");

            migrationBuilder.DropIndex(
                name: "IX_Styles_CustomRequestId",
                table: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_SizeCharts_CustomRequestId",
                table: "SizeCharts");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BillingInformationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ShippingInformationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_CustomRequestFabrics_CustomRequestId",
                table: "CustomRequestFabrics");

            migrationBuilder.DropColumn(
                name: "CustomRequestId",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "CustomRequestId",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BillInformationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BillingInformationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ShippingInformationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CustomRequestId",
                table: "CustomRequestFabrics");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Addresses",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CustomRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeChartId",
                table: "CustomRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "CustomRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_CustomRequests_AddressId",
                table: "CustomRequests",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequests_SizeChartId",
                table: "CustomRequests",
                column: "SizeChartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequests_StyleId",
                table: "CustomRequests",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestCustomRequestFabric_CustomRequestsId",
                table: "CustomRequestCustomRequestFabric",
                column: "CustomRequestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRequests_Addresses_AddressId",
                table: "CustomRequests",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRequests_SizeCharts_SizeChartId",
                table: "CustomRequests",
                column: "SizeChartId",
                principalTable: "SizeCharts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRequests_Styles_StyleId",
                table: "CustomRequests",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequests_Addresses_AddressId",
                table: "CustomRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequests_SizeCharts_SizeChartId",
                table: "CustomRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomRequests_Styles_StyleId",
                table: "CustomRequests");

            migrationBuilder.DropTable(
                name: "CustomRequestCustomRequestFabric");

            migrationBuilder.DropIndex(
                name: "IX_CustomRequests_AddressId",
                table: "CustomRequests");

            migrationBuilder.DropIndex(
                name: "IX_CustomRequests_SizeChartId",
                table: "CustomRequests");

            migrationBuilder.DropIndex(
                name: "IX_CustomRequests_StyleId",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "SizeChartId",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "CustomRequests");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Addresses",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "CustomRequestId",
                table: "Styles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomRequestId",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillInformationId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillingInformationId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingInformationId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomRequestId",
                table: "CustomRequestFabrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BillingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalGovernmentId = table.Column<int>(type: "int", nullable: true),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingInformations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingInformations_Local_Governments_LocalGovernmentId",
                        column: x => x.LocalGovernmentId,
                        principalTable: "Local_Governments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingInformations_States_stateId",
                        column: x => x.stateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalGovernmentId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingInformations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShippingInformations_Local_Governments_LocalGovernmentId",
                        column: x => x.LocalGovernmentId,
                        principalTable: "Local_Governments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShippingInformations_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Styles_CustomRequestId",
                table: "Styles",
                column: "CustomRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SizeCharts_CustomRequestId",
                table: "SizeCharts",
                column: "CustomRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillingInformationId",
                table: "Payments",
                column: "BillingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ShippingInformationId",
                table: "Payments",
                column: "ShippingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestFabrics_CustomRequestId",
                table: "CustomRequestFabrics",
                column: "CustomRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInformations_LocalGovernmentId",
                table: "BillingInformations",
                column: "LocalGovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInformations_stateId",
                table: "BillingInformations",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInformations_UserId",
                table: "BillingInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInformations_LocalGovernmentId",
                table: "ShippingInformations",
                column: "LocalGovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInformations_StateId",
                table: "ShippingInformations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInformations_UserId",
                table: "ShippingInformations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRequestFabrics_CustomRequests_CustomRequestId",
                table: "CustomRequestFabrics",
                column: "CustomRequestId",
                principalTable: "CustomRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_BillingInformations_BillingInformationId",
                table: "Payments",
                column: "BillingInformationId",
                principalTable: "BillingInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_ShippingInformations_ShippingInformationId",
                table: "Payments",
                column: "ShippingInformationId",
                principalTable: "ShippingInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeCharts_CustomRequests_CustomRequestId",
                table: "SizeCharts",
                column: "CustomRequestId",
                principalTable: "CustomRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_CustomRequests_CustomRequestId",
                table: "Styles",
                column: "CustomRequestId",
                principalTable: "CustomRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
