using Microsoft.EntityFrameworkCore;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Context;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly WTSuccessContext _context;
        private readonly DbSet<Student> _dbSet;
        public StudentRepository(WTSuccessContext dbcontext)
        {
            _dbSet = dbcontext.Set<Student>();
            _context = dbcontext;
        }

        public override void Add(Student entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public override void Update(Student entity, ulong id)
        {
            var dbValue = _dbSet.Find(id);
            if (dbValue != null)
            {
                dbValue.Name= entity.Name;
                dbValue.Email= entity.Email;
                dbValue.Password= entity.Password;
                _dbSet.Update(dbValue);
                _context.SaveChanges();
            }
        }

        public override Student GetById(ulong id)
        {
            var dbValue= _dbSet.Find(id);
            return dbValue;
        }
    }
}
