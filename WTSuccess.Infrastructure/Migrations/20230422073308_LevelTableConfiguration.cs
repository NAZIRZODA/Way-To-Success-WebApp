using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WTSuccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LevelTableConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstStudentId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    SecondStudentId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    WinnerStudentId = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LevelWithNumber = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    GamePlayerId = table.Column<long>(type: "bigint", nullable: false),
                    GameQuestionId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    GameQuestionAnswerId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    IsTrue = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_GamePlayer_GamePlayerId",
                        column: x => x.GamePlayerId,
                        principalTable: "GamePlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameQuestion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LevelWithNumberId = table.Column<long>(type: "bigint", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameQuestion_Level_LevelWithNumberId",
                        column: x => x.LevelWithNumberId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<long>(type: "bigint", nullable: false),
                    StudentsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExam_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Teory = table.Column<string>(type: "text", nullable: false),
                    ChapterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameQuestionAnswer_GameQuestion_GameQuestionId",
                        column: x => x.GameQuestionId,
                        principalTable: "GameQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    isCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudenExamId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    AnswerId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    IsTrue = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_StudentExam_StudenExamId",
                        column: x => x.StudenExamId,
                        principalTable: "StudentExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_CourseId",
                table: "Chapter",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GamePlayerId",
                table: "Game",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameQuestion_LevelWithNumberId",
                table: "GameQuestion",
                column: "LevelWithNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_GameQuestionAnswer_GameQuestionId",
                table: "GameQuestionAnswer",
                column: "GameQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ChapterId",
                table: "Question",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_StudenExamId",
                table: "StudentAnswer",
                column: "StudenExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ChapterId",
                table: "StudentExam",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ChapterId",
                table: "Topic",
                column: "ChapterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameQuestionAnswer");

            migrationBuilder.DropTable(
                name: "StudentAnswer");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "GameQuestion");

            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
