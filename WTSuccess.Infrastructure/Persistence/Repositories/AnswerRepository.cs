using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models.ExamScene;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private readonly DbSet<Answer> _dbAnswer;
        private readonly EFContext _context;
        public AnswerRepository(EFContext context) : base(context)
        {
            _dbAnswer = context.Set<Answer>();
            _context = context;
        }
    }
}
