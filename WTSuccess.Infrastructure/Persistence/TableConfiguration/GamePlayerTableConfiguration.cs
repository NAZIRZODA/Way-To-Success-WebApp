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
    public class GamePlayerTableConfiguration : IEntityTypeConfiguration<GamePlayer>
    {
        public void Configure(EntityTypeBuilder<GamePlayer> builder)
        {
            builder.ToTable(nameof(GamePlayer));
            builder.Property(i => i.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(i=>i.Id);
        }
    }
}
