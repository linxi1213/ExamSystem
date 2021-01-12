using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class Addisactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "ExamTestPapers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "ExamTestPapers");
        }
    }
}
