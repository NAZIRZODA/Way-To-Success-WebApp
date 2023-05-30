using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.CourseScene;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Infrastructure.Persistence.TableConfiguration
{
    public class GameQuestionTableConfiguration : IEntityTypeConfiguration<GameQuestion>
    {
        public void Configure(EntityTypeBuilder<GameQuestion> builder)
        {
            builder.ToTable(nameof(GameQuestion));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Level)
                .WithMany(s => s.GameQuestion)
                .HasForeignKey(s=> s.LevelWithNumberId);
        }
    }
}
