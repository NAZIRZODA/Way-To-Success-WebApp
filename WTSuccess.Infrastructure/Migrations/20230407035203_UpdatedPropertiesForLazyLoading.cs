using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WTSuccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPropertiesForLazyLoading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Topic",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chapter",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chapter");
        }
    }
}
