using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class changesSetver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamNum",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "ExamPassword",
                table: "Examinees");

            migrationBuilder.AddColumn<string>(
                name: "ExamLoginNum",
                table: "Examinees",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExamLoginPassword",
                table: "Examinees",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamLoginNum",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "ExamLoginPassword",
                table: "Examinees");

            migrationBuilder.AddColumn<string>(
                name: "ExamNum",
                table: "Examinees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExamPassword",
                table: "Examinees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
