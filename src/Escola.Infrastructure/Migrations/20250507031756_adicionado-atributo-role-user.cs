using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoatributoroleuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "user",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");
        }
    }
}
