using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.CourseScene;

namespace WTSuccess.Infrastructure.Persistence.TableConfiguration
{
    public class TopicTableConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable(nameof(Topic));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Chapter).WithMany(c => c.Topics).HasForeignKey(t => t.ChapterId);
        }
    }
}
