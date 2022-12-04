using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    public partial class childID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Children_ChildId",
                table: "Toys");

            migrationBuilder.AlterColumn<int>(
                name: "ChildId",
                table: "Toys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Children_ChildId",
                table: "Toys",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Children_ChildId",
                table: "Toys");

            migrationBuilder.AlterColumn<int>(
                name: "ChildId",
                table: "Toys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Children_ChildId",
                table: "Toys",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id");
        }
    }
}
