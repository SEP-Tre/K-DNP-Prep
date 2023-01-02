using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API.Migrations
{
    public partial class InitalCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamName1",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamName1",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamName1",
                table: "Player");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Player",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "TeamNameRef",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamName",
                table: "Player",
                column: "TeamName");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamName",
                table: "Player",
                column: "TeamName",
                principalTable: "Team",
                principalColumn: "TeamName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamName",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamName",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamNameRef",
                table: "Player");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Player",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName1",
                table: "Player",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamName1",
                table: "Player",
                column: "TeamName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamName1",
                table: "Player",
                column: "TeamName1",
                principalTable: "Team",
                principalColumn: "TeamName");
        }
    }
}
