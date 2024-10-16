using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMW.Migrations
{
    /// <inheritdoc />
    public partial class AddStatesAndLocalgovernments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "local_governments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    stateid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_governments", x => x.id);
                    table.ForeignKey(
                        name: "FK_local_governments_states_stateid",
                        column: x => x.stateid,
                        principalTable: "states",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_local_governments_stateid",
                table: "local_governments",
                column: "stateid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "local_governments");

            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
