using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Infrastructure.Persistence.TableConfiguration
{
    public class StudentAnswerTableConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.ToTable(nameof(StudentAnswer));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.HasOne(s => s.StudentExam).WithMany(s => s.StudentAnswers).HasForeignKey(x => x.StudenExamId);
        }
    }
}
