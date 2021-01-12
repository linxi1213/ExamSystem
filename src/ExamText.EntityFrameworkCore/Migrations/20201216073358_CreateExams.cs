using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class CreateExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamCompletions",
                columns: table => new
                {
                    ExamCompletionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamCompletions", x => x.ExamCompletionID);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    TrueAnswer = table.Column<string>(nullable: false),
                    OrtherAnswerOne = table.Column<string>(nullable: false),
                    OrtherAnswerTwo = table.Column<string>(nullable: false),
                    OrtherAnswerThree = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamCompletions");

            migrationBuilder.DropTable(
                name: "ExamQuestion");
        }
    }
}
