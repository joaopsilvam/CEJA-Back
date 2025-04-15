using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordResetFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_class_class_id",
                table: "student");

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetTokenExpiry",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "class_id",
                table: "student",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "user");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiry",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "class_id",
                table: "student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
