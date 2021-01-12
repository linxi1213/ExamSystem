using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class chang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamLoginNum",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "ExamLoginPassword",
                table: "Examinees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Examinees");

            migrationBuilder.RenameColumn(
                name: "ExamnesID",
                table: "Examinees",
                newName: "Id");

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Examinees",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Examinees",
                newName: "ExamnesID");

            migrationBuilder.AlterColumn<int>(
                name: "ExamnesID",
                table: "Examinees",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ExamLoginNum",
                table: "Examinees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExamLoginPassword",
                table: "Examinees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Examinees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
