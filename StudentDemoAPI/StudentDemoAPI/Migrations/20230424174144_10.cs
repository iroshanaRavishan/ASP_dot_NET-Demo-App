using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
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
    }
}
