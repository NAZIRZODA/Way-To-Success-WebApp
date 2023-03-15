using Microsoft.EntityFrameworkCore;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Context;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(WTSuccessContext context) : base(context)
        {
        }
    }
}
