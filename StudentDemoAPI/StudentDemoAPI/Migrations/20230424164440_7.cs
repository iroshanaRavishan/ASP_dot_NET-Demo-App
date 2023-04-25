using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolmentStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
