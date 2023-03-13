using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SortWasteVictoria_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bin",
                columns: table => new
                {
                    BinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bin", x => x.BinId);
                });

            migrationBuilder.CreateTable(
                name: "Garbage",
                columns: table => new
                {
                    GarbageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarbageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garbage", x => x.GarbageId);
                    table.ForeignKey(
                        name: "FK_Garbage_Bin_BinId",
                        column: x => x.BinId,
                        principalTable: "Bin",
                        principalColumn: "BinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garbage_BinId",
                table: "Garbage",
                column: "BinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garbage");

            migrationBuilder.DropTable(
                name: "Bin");
        }
    }
}
