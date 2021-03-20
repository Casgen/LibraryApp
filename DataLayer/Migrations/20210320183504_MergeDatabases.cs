using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class MergeDatabases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Categories_CategoryID",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Publications");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_CategoryId",
                table: "Publications",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ImageId",
                table: "Publications",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Categories_CategoryId",
                table: "Publications",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Categories_CategoryId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_CategoryId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_ImageId",
                table: "Publications");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Publications",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Categories_CategoryID",
                table: "Publications",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
