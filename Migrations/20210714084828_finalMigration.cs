using Microsoft.EntityFrameworkCore.Migrations;

namespace UnblockMe.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarRating_AspNetUsers_userId",
                table: "StarRating");

            migrationBuilder.DropIndex(
                name: "IX_StarRating_userId",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "RateTotal",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "StarRating",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StarRating_AspNetUserId",
                table: "StarRating",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StarRating_AspNetUsers_AspNetUserId",
                table: "StarRating",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarRating_AspNetUsers_AspNetUserId",
                table: "StarRating");

            migrationBuilder.DropIndex(
                name: "IX_StarRating_AspNetUserId",
                table: "StarRating");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "StarRating",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "StarRating",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateTotal",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StarRating_userId",
                table: "StarRating",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_StarRating_AspNetUsers_userId",
                table: "StarRating",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
