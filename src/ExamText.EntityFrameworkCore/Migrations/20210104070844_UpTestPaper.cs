using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class UpTestPaper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brach",
                table: "ExamTestPapers");

            migrationBuilder.DropColumn(
                name: "brach",
                table: "ExamShortAnswerQuestion");

            migrationBuilder.AddColumn<int>(
                name: "branch",
                table: "ExamTestPapers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "branch",
                table: "ExamShortAnswerQuestion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branch",
                table: "ExamTestPapers");

            migrationBuilder.DropColumn(
                name: "branch",
                table: "ExamShortAnswerQuestion");

            migrationBuilder.AddColumn<int>(
                name: "brach",
                table: "ExamTestPapers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "brach",
                table: "ExamShortAnswerQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
