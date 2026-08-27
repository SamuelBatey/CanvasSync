using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanvasSync.Migrations
{
    /// <inheritdoc />
    public partial class AddColorToStroke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Stroke",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "#000000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Stroke");
        }
    }
}
