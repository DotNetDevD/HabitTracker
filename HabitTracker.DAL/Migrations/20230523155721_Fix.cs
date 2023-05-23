using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitTracker.DAL.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habit_AspNetUsers_ApplicationUserId",
                table: "Habit");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Habit",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_AspNetUsers_ApplicationUserId",
                table: "Habit",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habit_AspNetUsers_ApplicationUserId",
                table: "Habit");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Habit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_AspNetUsers_ApplicationUserId",
                table: "Habit",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
