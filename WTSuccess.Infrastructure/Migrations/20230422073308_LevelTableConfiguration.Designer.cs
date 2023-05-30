﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WTSuccess.Infrastructure.Persistence.DataBases;

#nullable disable

namespace WTSuccess.Infrastructure.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20230422073308_LevelTableConfiguration")]
    partial class LevelTableConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<long>("CoursesId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentsId")
                        .HasColumnType("bigint");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Chapter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Chapter", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Topic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ChapterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Teory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Topic", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ChapterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.StudentAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("AnswerId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("IsTrue")
                        .HasColumnType("boolean");

                    b.Property<decimal>("QuestionId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("StudenExamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudenExamId");

                    b.ToTable("StudentAnswer", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.StudentExam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ChapterId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("StudentId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("StudentExam", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("GamePlayerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("GameQuestionAnswerId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("GameQuestionId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("IsTrue")
                        .HasColumnType("boolean");

                    b.Property<decimal>("StudentId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GamePlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("FirstStudentId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("SecondStudentId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("WinnerStudentId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("GamePlayer", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GameQuestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("LevelWithNumberId")
                        .HasColumnType("bigint");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LevelWithNumberId");

                    b.ToTable("GameQuestion", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GameQuestionAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("GameQuestionId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameQuestionId");

                    b.ToTable("GameQuestionAnswer", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.Level", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("LevelWithNumber")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("Level", (string)null);
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.CourseScene.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WTSuccess.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Chapter", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.CourseScene.Course", "Course")
                        .WithMany("Chapters")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Topic", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.CourseScene.Chapter", "Chapter")
                        .WithMany("Topics")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.Answer", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.ExamScene.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.Question", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.CourseScene.Chapter", "Chapter")
                        .WithMany("Questions")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.StudentAnswer", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.ExamScene.StudentExam", "StudentExam")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("StudenExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentExam");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.StudentExam", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.CourseScene.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.Game", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.GameScene.GamePlayer", "GamePlayer")
                        .WithMany("Games")
                        .HasForeignKey("GamePlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePlayer");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GameQuestion", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.GameScene.Level", "Level")
                        .WithMany("GameQuestion")
                        .HasForeignKey("LevelWithNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GameQuestionAnswer", b =>
                {
                    b.HasOne("WTSuccess.Domain.Models.GameScene.GameQuestion", "GameQuestion")
                        .WithMany("QuestionAnswer")
                        .HasForeignKey("GameQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameQuestion");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Chapter", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.CourseScene.Course", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.ExamScene.StudentExam", b =>
                {
                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GamePlayer", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.GameQuestion", b =>
                {
                    b.Navigation("QuestionAnswer");
                });

            modelBuilder.Entity("WTSuccess.Domain.Models.GameScene.Level", b =>
                {
                    b.Navigation("GameQuestion");
                });
#pragma warning restore 612, 618
        }
    }
}
