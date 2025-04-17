using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoatributoeducationlevelemclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "education_level",
                table: "class",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "education_level",
                table: "class");
        }
    }
}
