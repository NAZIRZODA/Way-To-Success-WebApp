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

        public override void Update(Student entity, ulong id)
        {
            var dbValue = Context.Set<Student>().Find(id);
            if (dbValue != null)
            {
                dbValue.Name = entity.Name;
                dbValue.Surname = entity.Surname;
                dbValue.Email = entity.Email;
            }
        }
    }
}
