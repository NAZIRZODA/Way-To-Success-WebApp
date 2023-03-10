using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Context
{
    public class WTSuccessContext : DbContext
    {
        //public WTSuccessContext( )
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}

        public WTSuccessContext(DbContextOptions<WTSuccessContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; } = null!;
       public DbSet<Course> Languages { get; set; }
       public DbSet<Exam> Exams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;DataBase=WayToSuccess;Password=2415");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StudentMapping(modelBuilder);
            LanguageMapping(modelBuilder);
            ExamMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        void StudentMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().HasKey(p=>p.Id);
        }

        void LanguageMapping(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Language>().HasKey(l => l.Id);
            modelBuilder.Entity<Student>().HasMany<Course>().WithOne(c => c.Student);
        }


        void ExamMapping(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Exam>().HasKey(e => e.Id);
            modelBuilder.Entity<Exam>().HasMany<Question>(e => e.Questions);//WithOne(q => q.Exam);
        }
    }
}
