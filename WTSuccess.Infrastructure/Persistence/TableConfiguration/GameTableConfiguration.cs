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
    public class GameTableConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(nameof(Game));
            builder.Property(i => i.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(i => i.Id);
            builder.HasOne(g => g.GamePlayer).WithMany(game => game.Games).HasForeignKey(game => game.GamePlayerId);
        }
    }
}
