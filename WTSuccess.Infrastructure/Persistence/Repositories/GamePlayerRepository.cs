using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models.GameScene;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class GamePlayerRepository : Repository<GamePlayer>, IGamePlayerRepository
    {
        private readonly DbSet<GamePlayer> _dbSetGamePlayer;
        private readonly EFContext _context;
        public GamePlayerRepository(EFContext context) : base(context)
        {
            _dbSetGamePlayer = context.Set<GamePlayer>();
            _context = context;
        }
    }
}
