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
    public class ChapterTableConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable(nameof(Chapter));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Course).WithMany(c => c.Chapters).HasForeignKey(c => c.CourseId);
        }
    }
}
