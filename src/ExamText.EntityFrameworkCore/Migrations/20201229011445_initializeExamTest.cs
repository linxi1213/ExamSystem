using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class initializeExamTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamTestPaperId",
                table: "ExamQuestion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamTestPaperId",
                table: "ExamCompletions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExamTestPapers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamQuestionIDs = table.Column<string>(nullable: true),
                    ExamCompletionIDs = table.Column<string>(nullable: true),
                    ExamShortAnswerQuestionIDs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTestPapers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamShortAnswerQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: false),
                    ExamTestPaperId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamShortAnswerQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamShortAnswerQuestion_ExamTestPapers_ExamTestPaperId",
                        column: x => x.ExamTestPaperId,
                        principalTable: "ExamTestPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamTestPaperId",
                table: "ExamQuestion",
                column: "ExamTestPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamCompletions_ExamTestPaperId",
                table: "ExamCompletions",
                column: "ExamTestPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamShortAnswerQuestion_ExamTestPaperId",
                table: "ExamShortAnswerQuestion",
                column: "ExamTestPaperId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamCompletions_ExamTestPapers_ExamTestPaperId",
                table: "ExamCompletions",
                column: "ExamTestPaperId",
                principalTable: "ExamTestPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ExamTestPapers_ExamTestPaperId",
                table: "ExamQuestion",
                column: "ExamTestPaperId",
                principalTable: "ExamTestPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamCompletions_ExamTestPapers_ExamTestPaperId",
                table: "ExamCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ExamTestPapers_ExamTestPaperId",
                table: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "ExamShortAnswerQuestion");

            migrationBuilder.DropTable(
                name: "ExamTestPapers");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_ExamTestPaperId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExamCompletions_ExamTestPaperId",
                table: "ExamCompletions");

            migrationBuilder.DropColumn(
                name: "ExamTestPaperId",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "ExamTestPaperId",
                table: "ExamCompletions");
        }
    }
}
