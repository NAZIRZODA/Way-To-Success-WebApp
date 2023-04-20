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
    public class GameQuestionRepository : Repository<GameQuestion>, IGameQuestionRepository
    {
        private readonly DbSet<GameQuestion> _dbSetGameQuestions;
        private readonly EFContext _context;
        public GameQuestionRepository(EFContext context) : base(context)
        {
            _dbSetGameQuestions= context.Set<GameQuestion>();
            _context= context;
        }
    }
}
