using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
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
                    EnrolmentStudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrolmentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentStudent", x => x.EnrolmentStudentId);
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_Enrolments_EnrolmentId",
                        column: x => x.EnrolmentId,
                        principalTable: "Enrolments",
                        principalColumn: "EnrolmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentStudent_EnrolmentId",
                table: "EnrolmentStudent",
                column: "EnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentStudent_StudentId",
                table: "EnrolmentStudent",
                column: "StudentId");
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
