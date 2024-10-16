using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddColorsToFabricAndStyleDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                table: "SizeCharts",
                newName: "WristGirth");

            migrationBuilder.RenameColumn(
                name: "MaleWrist",
                table: "SizeCharts",
                newName: "WaistGirth");

            migrationBuilder.RenameColumn(
                name: "MaleChestWidth",
                table: "SizeCharts",
                newName: "UnderBurstGirth_F");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "SizeCharts",
                newName: "ThighGirth");

            migrationBuilder.RenameColumn(
                name: "FemaleBurst",
                table: "SizeCharts",
                newName: "SleeveLength");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Fabrics",
                newName: "ImagePath3");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Fabrics",
                newName: "ImagePath2");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "CustomRequests",
                newName: "ThirdPartySex");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CustomRequests",
                newName: "ThirdPartyFirstName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "CustomRequests",
                newName: "ThirdPartyEmail");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CustomRequests",
                newName: "RequestId");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath1",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName1",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colors",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "StyleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StyleCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "StyleAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StyleAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnkleGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackWaistLength",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackWidth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BicepsGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodyHeight",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodyRise_F",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BurstLength_F",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BurstPointDistance_F",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalfGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChestGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChestWidth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElbowLength",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontLength_F",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HipGirth_F",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hipdepth_F",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KneeBandGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KneeLength",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LowerWaistGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SizeCharts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeckGirth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeckWidth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScyeDepth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScyeWidth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoulderWidth",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SideLength",
                table: "SizeCharts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Colors",
                table: "Fabrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FabricCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DeliveryAmount",
                table: "CustomRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PickUpAmount",
                table: "CustomRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "CustomRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "CustomRequestFabrics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colors",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "AnkleGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BackWaistLength",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BackWidth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BicepsGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BodyHeight",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BodyRise_F",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BurstLength_F",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "BurstPointDistance_F",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "CalfGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "ChestGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "ChestWidth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "ElbowLength",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "FrontLength_F",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "HeadGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "HipGirth_F",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "Hipdepth_F",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "KneeBandGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "KneeLength",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "LowerWaistGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "NeckGirth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "NeckWidth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "ScyeDepth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "ScyeWidth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "ShoulderWidth",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "SideLength",
                table: "SizeCharts");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Colors",
                table: "Fabrics");

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
                name: "DeliveryAmount",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "PickUpAmount",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "CustomRequests");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CustomRequestFabrics");

            migrationBuilder.RenameColumn(
                name: "WristGirth",
                table: "SizeCharts",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "WaistGirth",
                table: "SizeCharts",
                newName: "MaleWrist");

            migrationBuilder.RenameColumn(
                name: "UnderBurstGirth_F",
                table: "SizeCharts",
                newName: "MaleChestWidth");

            migrationBuilder.RenameColumn(
                name: "ThighGirth",
                table: "SizeCharts",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "SleeveLength",
                table: "SizeCharts",
                newName: "FemaleBurst");

            migrationBuilder.RenameColumn(
                name: "ImagePath3",
                table: "Fabrics",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImagePath2",
                table: "Fabrics",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "ThirdPartySex",
                table: "CustomRequests",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "ThirdPartyFirstName",
                table: "CustomRequests",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ThirdPartyEmail",
                table: "CustomRequests",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "CustomRequests",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath1",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName1",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "StyleCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StyleCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "StyleAttributes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StyleAttributes",
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
        }
    }
}
