using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class CreatFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserID",
                table: "Examinees",
                nullable: false);

            migrationBuilder.CreateIndex(
              name: "IX_Examinees_UserID",
              table: "Examinees",
              column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinees_AbpUsers_UserID",
                table: "Examinees",
                column: "UserID",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinees_AbpUsers_UserID",
                table: "Examinees");

            migrationBuilder.DropIndex(
                name: "IX_Examinees_UserID",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "UserID",
              table: "Examinees");
        }
    }
}
