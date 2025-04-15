using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Class_class_class_id",
                table: "Teachers_Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Class_teacher_teacher_id",
                table: "Teachers_Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers_Class",
                table: "Teachers_Class");

            migrationBuilder.RenameTable(
                name: "Teachers_Class",
                newName: "teacher_class");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_Class_class_id",
                table: "teacher_class",
                newName: "IX_teacher_class_class_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacher_class",
                table: "teacher_class",
                columns: new[] { "teacher_id", "class_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_class_class_class_id",
                table: "teacher_class",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_class_teacher_teacher_id",
                table: "teacher_class",
                column: "teacher_id",
                principalTable: "teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_class_class_class_id",
                table: "teacher_class");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_class_teacher_teacher_id",
                table: "teacher_class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacher_class",
                table: "teacher_class");

            migrationBuilder.RenameTable(
                name: "teacher_class",
                newName: "Teachers_Class");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_class_class_id",
                table: "Teachers_Class",
                newName: "IX_Teachers_Class_class_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers_Class",
                table: "Teachers_Class",
                columns: new[] { "teacher_id", "class_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Class_class_class_id",
                table: "Teachers_Class",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Class_teacher_teacher_id",
                table: "Teachers_Class",
                column: "teacher_id",
                principalTable: "teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
