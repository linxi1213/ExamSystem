using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class addBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "brach",
                table: "ExamTestPapers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "brach",
                table: "ExamShortAnswerQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "branch",
                table: "ExamCompletions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "branch",
                table: "ExamChoiceQuestion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brach",
                table: "ExamTestPapers");

            migrationBuilder.DropColumn(
                name: "brach",
                table: "ExamShortAnswerQuestion");

            migrationBuilder.DropColumn(
                name: "branch",
                table: "ExamCompletions");

            migrationBuilder.DropColumn(
                name: "branch",
                table: "ExamChoiceQuestion");
        }
    }
}
