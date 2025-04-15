using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correcoesrelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subject_class");

            migrationBuilder.AddColumn<int>(
                name: "subject_id",
                table: "grade",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teachers_Class",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "INTEGER", nullable: false),
                    class_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers_Class", x => new { x.teacher_id, x.class_id });
                    table.ForeignKey(
                        name: "FK_Teachers_Class_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Class_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_grade_subject_id",
                table: "grade",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Class_class_id",
                table: "Teachers_Class",
                column: "class_id");

            migrationBuilder.AddForeignKey(
                name: "FK_grade_subject_subject_id",
                table: "grade",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grade_subject_subject_id",
                table: "grade");

            migrationBuilder.DropTable(
                name: "Teachers_Class");

            migrationBuilder.DropIndex(
                name: "IX_grade_subject_id",
                table: "grade");

            migrationBuilder.DropColumn(
                name: "subject_id",
                table: "grade");

            migrationBuilder.CreateTable(
                name: "subject_class",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "INTEGER", nullable: false),
                    class_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_class", x => new { x.subject_id, x.class_id });
                    table.ForeignKey(
                        name: "FK_subject_class_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_class_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subject_class_class_id",
                table: "subject_class",
                column: "class_id");
        }
    }
}
