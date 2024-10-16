using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class CreateCustomRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    LocalGovernmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "CustomRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvidedFabric = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FabricCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    LocalGovernmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "StyleAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StyleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaleWrist = table.Column<int>(type: "int", nullable: false),
                    MaleChestWidth = table.Column<int>(type: "int", nullable: false),
                    FemaleBurst = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    CustomRequestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeCharts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SizeCharts_CustomRequests_CustomRequestId",
                        column: x => x.CustomRequestId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
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
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GatewayRequestId = table.Column<int>(type: "int", nullable: false),
                    BillInformationId = table.Column<int>(type: "int", nullable: false),
                    BillingInformationId = table.Column<int>(type: "int", nullable: true),
                    ShippingInformationId = table.Column<int>(type: "int", nullable: false),
                    CustomRequestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_BillingInformations_BillingInformationId",
                        column: x => x.BillingInformationId,
                        principalTable: "BillingInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_CustomRequests_CustomRequestId",
                        column: x => x.CustomRequestId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_ShippingInformations_ShippingInformationId",
                        column: x => x.ShippingInformationId,
                        principalTable: "ShippingInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabricSet = table.Column<int>(type: "int", nullable: false),
                    StyleCategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_CustomRequests_CustomRequestId",
                        column: x => x.CustomRequestId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Styles_StyleCategories_StyleCategoryId",
                        column: x => x.StyleCategoryId,
                        principalTable: "StyleCategories",
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
                    FabricId = table.Column<int>(type: "int", nullable: false),
                    CustomRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRequestFabrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomRequestFabrics_CustomRequests_CustomRequestId",
                        column: x => x.CustomRequestId,
                        principalTable: "CustomRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomRequestFabrics_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StyleStyleAttribute",
                columns: table => new
                {
                    StyleAttributesId = table.Column<int>(type: "int", nullable: false),
                    StylesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleStyleAttribute", x => new { x.StyleAttributesId, x.StylesId });
                    table.ForeignKey(
                        name: "FK_StyleStyleAttribute_StyleAttributes_StyleAttributesId",
                        column: x => x.StyleAttributesId,
                        principalTable: "StyleAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StyleStyleAttribute_Styles_StylesId",
                        column: x => x.StylesId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CustomRequestFabrics_CustomRequestId",
                table: "CustomRequestFabrics",
                column: "CustomRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequestFabrics_FabricId",
                table: "CustomRequestFabrics",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRequests_UserId",
                table: "CustomRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_FabricCategoryId",
                table: "Fabrics",
                column: "FabricCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillingInformationId",
                table: "Payments",
                column: "BillingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomRequestId",
                table: "Payments",
                column: "CustomRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ShippingInformationId",
                table: "Payments",
                column: "ShippingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
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

            migrationBuilder.CreateIndex(
                name: "IX_SizeCharts_CustomRequestId",
                table: "SizeCharts",
                column: "CustomRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SizeCharts_UserId",
                table: "SizeCharts",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_CustomRequestId",
                table: "Styles",
                column: "CustomRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Styles_StyleCategoryId",
                table: "Styles",
                column: "StyleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StyleStyleAttribute_StylesId",
                table: "StyleStyleAttribute",
                column: "StylesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomRequestFabrics");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SizeCharts");

            migrationBuilder.DropTable(
                name: "StyleStyleAttribute");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "BillingInformations");

            migrationBuilder.DropTable(
                name: "ShippingInformations");

            migrationBuilder.DropTable(
                name: "StyleAttributes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "FabricCategories");

            migrationBuilder.DropTable(
                name: "CustomRequests");

            migrationBuilder.DropTable(
                name: "StyleCategories");
        }
    }
}
