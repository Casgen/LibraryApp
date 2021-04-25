using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ImageOptional2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Images_ImageId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_ImageId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Publications");

            migrationBuilder.AddColumn<int>(
                name: "PublicationId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PublicationId",
                table: "Images",
                column: "PublicationId",
                unique: true,
                filter: "[PublicationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Publications_PublicationId",
                table: "Images",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Publications_PublicationId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PublicationId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PublicationId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Publications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ImageId",
                table: "Publications",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Images_ImageId",
                table: "Publications",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
