using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.TableConfiguration
{
    public class QuestionTableConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable(nameof(Question));
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Chapter).WithMany(ch => ch.Questions);
        }
    }
}