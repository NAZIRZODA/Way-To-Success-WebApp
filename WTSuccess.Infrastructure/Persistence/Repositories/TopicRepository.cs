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
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        private readonly DbSet<Topic> _dbTopic;
        private readonly EFContext _context;
        public TopicRepository(EFContext context) : base(context)
        {
            _dbTopic = context.Set<Topic>();
            _context = context;
        }
    }
}
