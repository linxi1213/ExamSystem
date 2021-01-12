using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamText.Migrations
{
    public partial class CreateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
               // name: "FK_Examinees_AbpUsers_UserID",
              //  table: "Examinees");

            //migrationBuilder.DropIndex(
              //  name: "IX_Examinees_UserID",
               // table: "Examinees");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.CreateIndex(
             //   name: "IX_Examinees_UserID",
             //   table: "Examinees",
              //  column: "UserID");

           // migrationBuilder.AddForeignKey(
               // name: "FK_Examinees_AbpUsers_UserID",
               // table: "Examinees",
               // column: "UserID",
              //  principalTable: "AbpUsers",
              //  principalColumn: "Id",
              //  onDelete: ReferentialAction.Cascade);
        }
    }
}
