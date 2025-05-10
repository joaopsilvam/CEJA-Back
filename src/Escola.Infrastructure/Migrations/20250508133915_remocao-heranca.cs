using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remocaoheranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_user_Id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_user_Id",
                table: "teacher");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "teacher",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "student",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "born_date",
                table: "teacher",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "document",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_reset_token",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "password_reset_token_expiry",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "teacher",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "born_date",
                table: "student",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "document",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_reset_token",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "password_reset_token_expiry",
                table: "student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "student",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "avatar",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "born_date",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "document",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "email",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "name",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "password",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "password_reset_token",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "password_reset_token_expiry",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "teacher");

            migrationBuilder.DropColumn(
                name: "address",
                table: "student");

            migrationBuilder.DropColumn(
                name: "avatar",
                table: "student");

            migrationBuilder.DropColumn(
                name: "born_date",
                table: "student");

            migrationBuilder.DropColumn(
                name: "document",
                table: "student");

            migrationBuilder.DropColumn(
                name: "email",
                table: "student");

            migrationBuilder.DropColumn(
                name: "name",
                table: "student");

            migrationBuilder.DropColumn(
                name: "password",
                table: "student");

            migrationBuilder.DropColumn(
                name: "password_reset_token",
                table: "student");

            migrationBuilder.DropColumn(
                name: "password_reset_token_expiry",
                table: "student");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "student");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "teacher",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "student",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_user_Id",
                table: "student",
                column: "Id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_user_Id",
                table: "teacher",
                column: "Id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
