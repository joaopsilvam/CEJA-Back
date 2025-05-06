using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaorelacionamentograde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grade_subject_subject_id",
                table: "grade");

            migrationBuilder.DropIndex(
                name: "IX_grade_subject_id",
                table: "grade");

            migrationBuilder.DropColumn(
                name: "subject_id",
                table: "grade");

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                table: "subject",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_subject_student_id",
                table: "subject",
                column: "student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_subject_student_student_id",
                table: "subject",
                column: "student_id",
                principalTable: "student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subject_student_student_id",
                table: "subject");

            migrationBuilder.DropIndex(
                name: "IX_subject_student_id",
                table: "subject");

            migrationBuilder.DropColumn(
                name: "student_id",
                table: "subject");

            migrationBuilder.AddColumn<int>(
                name: "subject_id",
                table: "grade",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_grade_subject_id",
                table: "grade",
                column: "subject_id");

            migrationBuilder.AddForeignKey(
                name: "FK_grade_subject_subject_id",
                table: "grade",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
