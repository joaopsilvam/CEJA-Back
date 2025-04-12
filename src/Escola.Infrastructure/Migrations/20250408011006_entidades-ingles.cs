using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class entidadesingles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nota");

            migrationBuilder.DropTable(
                name: "professor_disciplina");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "disciplina");

            migrationBuilder.DropTable(
                name: "professor");

            migrationBuilder.DropTable(
                name: "turma");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Avatar = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Document = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    BornDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    class_id = table.Column<int>(type: "INTEGER", nullable: false),
                    registration_number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_user_Id",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacher_user_Id",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    student_id = table.Column<int>(type: "INTEGER", nullable: false),
                    subject_id = table.Column<int>(type: "INTEGER", nullable: false),
                    teacher_id = table.Column<int>(type: "INTEGER", nullable: false),
                    grade_value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.id);
                    table.ForeignKey(
                        name: "FK_grade_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grade_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grade_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_subject",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "INTEGER", nullable: false),
                    subject_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_subject", x => new { x.teacher_id, x.subject_id });
                    table.ForeignKey(
                        name: "FK_teacher_subject_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_subject_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_grade_student_id",
                table: "grade",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_grade_subject_id",
                table: "grade",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_grade_teacher_id",
                table: "grade",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_class_id",
                table: "student",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_subject_subject_id",
                table: "teacher_subject",
                column: "subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grade");

            migrationBuilder.DropTable(
                name: "teacher_subject");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.CreateTable(
                name: "disciplina",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_turma = table.Column<int>(type: "INTEGER", nullable: false),
                    matricula = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aluno_turma_id_turma",
                        column: x => x.id_turma,
                        principalTable: "turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aluno_usuario_Id",
                        column: x => x.Id,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professor_usuario_Id",
                        column: x => x.Id,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nota",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_aluno = table.Column<int>(type: "INTEGER", nullable: false),
                    id_disciplina = table.Column<int>(type: "INTEGER", nullable: false),
                    id_professor = table.Column<int>(type: "INTEGER", nullable: false),
                    valor_nota = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nota", x => x.id);
                    table.ForeignKey(
                        name: "FK_nota_aluno_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nota_disciplina_id_disciplina",
                        column: x => x.id_disciplina,
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nota_professor_id_professor",
                        column: x => x.id_professor,
                        principalTable: "professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professor_disciplina",
                columns: table => new
                {
                    id_professor = table.Column<int>(type: "INTEGER", nullable: false),
                    id_disciplina = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor_disciplina", x => new { x.id_professor, x.id_disciplina });
                    table.ForeignKey(
                        name: "FK_professor_disciplina_disciplina_id_disciplina",
                        column: x => x.id_disciplina,
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professor_disciplina_professor_id_professor",
                        column: x => x.id_professor,
                        principalTable: "professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_id_turma",
                table: "aluno",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "IX_nota_id_aluno",
                table: "nota",
                column: "id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_nota_id_disciplina",
                table: "nota",
                column: "id_disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_nota_id_professor",
                table: "nota",
                column: "id_professor");

            migrationBuilder.CreateIndex(
                name: "IX_professor_disciplina_id_disciplina",
                table: "professor_disciplina",
                column: "id_disciplina");
        }
    }
}
