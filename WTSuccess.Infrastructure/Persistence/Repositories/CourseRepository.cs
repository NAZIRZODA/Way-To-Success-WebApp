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
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly DbSet<Course> _dbCourse;
        private readonly EFContext _context;
        public CourseRepository(EFContext context) : base(context)
        {
            _dbCourse = context.Set<Course>();
            _context = context;
        }
    }
}
