using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WTSuccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VirtualPropertiesForLazyLoading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ChapterId",
                table: "StudentExam",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ChapterId",
                table: "StudentExam",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_Chapter_ChapterId",
                table: "StudentExam",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_Chapter_ChapterId",
                table: "StudentExam");

            migrationBuilder.DropIndex(
                name: "IX_StudentExam_ChapterId",
                table: "StudentExam");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChapterId",
                table: "StudentExam",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
