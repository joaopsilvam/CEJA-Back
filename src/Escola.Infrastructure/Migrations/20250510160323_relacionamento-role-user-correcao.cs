using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentoroleusercorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_teacher_role_id",
                table: "teacher");

            migrationBuilder.DropIndex(
                name: "IX_student_role_id",
                table: "student");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_role_id",
                table: "teacher",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_role_id",
                table: "student",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_teacher_role_id",
                table: "teacher");

            migrationBuilder.DropIndex(
                name: "IX_student_role_id",
                table: "student");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_role_id",
                table: "teacher",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_role_id",
                table: "student",
                column: "role_id",
                unique: true);
        }
    }
}
