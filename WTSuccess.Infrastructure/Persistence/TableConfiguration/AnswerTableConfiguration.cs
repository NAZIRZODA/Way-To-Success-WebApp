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
    public class AnswerTableConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable(nameof(Answer));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Question).WithMany(q => q.Answers);
        }
    }
}
