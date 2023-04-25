using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrolmentEnrolmetId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrolmentEnrolmetId",
                table: "Students",
                column: "EnrolmentEnrolmetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Enrolments_EnrolmentEnrolmetId",
                table: "Students",
                column: "EnrolmentEnrolmetId",
                principalTable: "Enrolments",
                principalColumn: "EnrolmetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Enrolments_EnrolmentEnrolmetId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_EnrolmentEnrolmetId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrolmentEnrolmetId",
                table: "Students");
        }
    }
}
