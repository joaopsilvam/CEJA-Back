using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "class",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "suffix",
                table: "class",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "class",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "period",
                table: "class");

            migrationBuilder.DropColumn(
                name: "suffix",
                table: "class");

            migrationBuilder.DropColumn(
                name: "year",
                table: "class");
        }
    }
}
