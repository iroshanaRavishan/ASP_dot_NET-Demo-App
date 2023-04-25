using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EnrolmentStudent",
                columns: table => new
                {
                    EnrolmentsEnrolmetId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentStudent", x => new { x.EnrolmentsEnrolmetId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_Enrolments_EnrolmentsEnrolmetId",
                        column: x => x.EnrolmentsEnrolmetId,
                        principalTable: "Enrolments",
                        principalColumn: "EnrolmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentStudent_StudentsStudentId",
                table: "EnrolmentStudent",
                column: "StudentsStudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolmentStudent");

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
    }
}
