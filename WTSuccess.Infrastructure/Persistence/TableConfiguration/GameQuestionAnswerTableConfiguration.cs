using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Infrastructure.Persistence.TableConfiguration
{
    public class GameQuestionAnswerTableConfiguration : IEntityTypeConfiguration<GameQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<GameQuestionAnswer> builder)
        {
            builder.ToTable(nameof(GameQuestionAnswer));
            builder.Property(i => i.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(i => i.Id);
            builder.HasOne(q => q.GameQuestion).WithMany(a => a.QuestionAnswer).HasForeignKey(qi => qi.GameQuestionId);
        }
    }
}
