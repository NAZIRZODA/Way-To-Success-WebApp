using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class StudentAnswerRepository : Repository<StudentAnswer>
    {
        private readonly DbSet<Course> _dbStudentAnswer;
        private readonly EFContext _context;
        public StudentAnswerRepository(EFContext context) : base(context)
        {
            _dbStudentAnswer = context.Set<Course>();
            _context = context;
        }
    }
}
