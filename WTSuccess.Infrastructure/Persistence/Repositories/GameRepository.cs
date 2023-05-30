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
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private readonly DbSet<Game> _dbSetGame;
        private readonly EFContext _context;
        public GameRepository(EFContext context) : base(context)
        {
            _dbSetGame = context.Set<Game>();
            _context = context;
        }
    }
}
