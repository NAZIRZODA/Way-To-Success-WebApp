using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Context;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ILanguageRepository
    {
        public CourseRepository(WTSuccessContext dbcontext) 
        {
        }
    }
}
