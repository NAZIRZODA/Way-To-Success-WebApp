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
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        private readonly DbSet<Level> _dbSetLevels;
        private readonly EFContext _context;
        public LevelRepository(EFContext context) : base(context)
        {
            _dbSetLevels = context.Set<Level>();
            _context = context;
        }
    }
}
