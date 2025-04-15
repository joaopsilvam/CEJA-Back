using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizacoesgerais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grade_subject_subject_id",
                table: "grade");

            migrationBuilder.DropForeignKey(
                name: "FK_grade_teacher_teacher_id",
                table: "grade");

            migrationBuilder.DropForeignKey(
                name: "FK_student_class_class_id",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_grade_subject_id",
                table: "grade");

            migrationBuilder.DropIndex(
                name: "IX_grade_teacher_id",
                table: "grade");

            migrationBuilder.DropColumn(
                name: "subject_id",
                table: "grade");

            migrationBuilder.DropColumn(
                name: "teacher_id",
                table: "grade");

            migrationBuilder.AlterColumn<int>(
                name: "class_id",
                table: "student",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Subjects_Class",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "INTEGER", nullable: false),
                    class_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects_Class", x => new { x.subject_id, x.class_id });
                    table.ForeignKey(
                        name: "FK_Subjects_Class_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Class_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Class_class_id",
                table: "Subjects_Class",
                column: "class_id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_class_class_id",
                table: "student",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_class_class_id",
                table: "student");

            migrationBuilder.DropTable(
                name: "Subjects_Class");

            migrationBuilder.AlterColumn<int>(
                name: "class_id",
                table: "student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subject_id",
                table: "grade",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacher_id",
                table: "grade",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_grade_subject_id",
                table: "grade",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_grade_teacher_id",
                table: "grade",
                column: "teacher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_grade_subject_subject_id",
                table: "grade",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grade_teacher_teacher_id",
                table: "grade",
                column: "teacher_id",
                principalTable: "teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_class_class_id",
                table: "student",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
