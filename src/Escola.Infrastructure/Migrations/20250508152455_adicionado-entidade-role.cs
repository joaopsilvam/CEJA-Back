using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoentidaderole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "teacher",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_student_role_role_id",
                table: "student",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_role_role_id",
                table: "teacher",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_role_role_id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_role_role_id",
                table: "teacher");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropIndex(
                name: "IX_teacher_role_id",
                table: "teacher");

            migrationBuilder.DropIndex(
                name: "IX_student_role_id",
                table: "student");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "student");
        }
    }
}
