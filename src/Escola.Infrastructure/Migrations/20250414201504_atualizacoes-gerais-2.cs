using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizacoesgerais2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Class_class_class_id",
                table: "Subjects_Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Class_subject_subject_id",
                table: "Subjects_Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects_Class",
                table: "Subjects_Class");

            migrationBuilder.RenameTable(
                name: "Subjects_Class",
                newName: "subject_class");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_Class_class_id",
                table: "subject_class",
                newName: "IX_subject_class_class_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subject_class",
                table: "subject_class",
                columns: new[] { "subject_id", "class_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_subject_class_class_class_id",
                table: "subject_class",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_class_subject_subject_id",
                table: "subject_class",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subject_class_class_class_id",
                table: "subject_class");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_class_subject_subject_id",
                table: "subject_class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subject_class",
                table: "subject_class");

            migrationBuilder.RenameTable(
                name: "subject_class",
                newName: "Subjects_Class");

            migrationBuilder.RenameIndex(
                name: "IX_subject_class_class_id",
                table: "Subjects_Class",
                newName: "IX_Subjects_Class_class_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects_Class",
                table: "Subjects_Class",
                columns: new[] { "subject_id", "class_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Class_class_class_id",
                table: "Subjects_Class",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Class_subject_subject_id",
                table: "Subjects_Class",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
