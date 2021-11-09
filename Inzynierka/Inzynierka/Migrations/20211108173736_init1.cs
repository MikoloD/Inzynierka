using Microsoft.EntityFrameworkCore.Migrations;

namespace Inzynierka.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    NodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.NodeId);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    EdgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceNodeId = table.Column<int>(type: "int", nullable: true),
                    TargetNodeId = table.Column<int>(type: "int", nullable: true),
                    Wage = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.EdgeId);
                    table.ForeignKey(
                        name: "FK_Roads_Cities_SourceNodeId",
                        column: x => x.SourceNodeId,
                        principalTable: "Cities",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roads_Cities_TargetNodeId",
                        column: x => x.TargetNodeId,
                        principalTable: "Cities",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roads_SourceNodeId",
                table: "Roads",
                column: "SourceNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roads_TargetNodeId",
                table: "Roads",
                column: "TargetNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
