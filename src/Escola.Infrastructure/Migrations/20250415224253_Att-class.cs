using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enceja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Attclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "class");

            migrationBuilder.RenameColumn(
                name: "period",
                table: "class",
                newName: "shift");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shift",
                table: "class",
                newName: "period");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "class",
                type: "TEXT",
                nullable: true);
        }
    }
}
