using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class ChapterRepository : Repository<Chapter>, IChapterRepository
    {
        private readonly DbSet<Chapter> _dbChapter;
        private readonly EFContext _context;
        public ChapterRepository(EFContext context) : base(context)
        {
            _dbChapter = context.Set<Chapter>();
            _context = context;
        }
    }
}
