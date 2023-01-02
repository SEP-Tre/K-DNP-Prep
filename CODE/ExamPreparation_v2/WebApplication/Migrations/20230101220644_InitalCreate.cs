using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MockModels",
                columns: table => new
                {
                    ValueOne = table.Column<string>(type: "TEXT", nullable: false),
                    ValueTwo = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockModels", x => x.ValueOne);
                });

            migrationBuilder.CreateTable(
                name: "MockModelThrees",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MockModelValueOne = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MockModelThrees", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MockModelThrees_MockModels_MockModelValueOne",
                        column: x => x.MockModelValueOne,
                        principalTable: "MockModels",
                        principalColumn: "ValueOne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MockModelThrees_MockModelValueOne",
                table: "MockModelThrees",
                column: "MockModelValueOne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MockModelThrees");

            migrationBuilder.DropTable(
                name: "MockModels");
        }
    }
}
