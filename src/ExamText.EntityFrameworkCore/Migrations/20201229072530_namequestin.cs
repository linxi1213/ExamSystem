using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class namequestin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ExamTestPapers_ExamTestPaperId",
                table: "ExamQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion");

            migrationBuilder.RenameTable(
                name: "ExamQuestion",
                newName: "ExamChoiceQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestion_ExamTestPaperId",
                table: "ExamChoiceQuestion",
                newName: "IX_ExamChoiceQuestion_ExamTestPaperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamChoiceQuestion",
                table: "ExamChoiceQuestion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamChoiceQuestion_ExamTestPapers_ExamTestPaperId",
                table: "ExamChoiceQuestion",
                column: "ExamTestPaperId",
                principalTable: "ExamTestPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamChoiceQuestion_ExamTestPapers_ExamTestPaperId",
                table: "ExamChoiceQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamChoiceQuestion",
                table: "ExamChoiceQuestion");

            migrationBuilder.RenameTable(
                name: "ExamChoiceQuestion",
                newName: "ExamQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_ExamChoiceQuestion_ExamTestPaperId",
                table: "ExamQuestion",
                newName: "IX_ExamQuestion_ExamTestPaperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ExamTestPapers_ExamTestPaperId",
                table: "ExamQuestion",
                column: "ExamTestPaperId",
                principalTable: "ExamTestPapers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
