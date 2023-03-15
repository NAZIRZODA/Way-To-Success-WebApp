using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Context;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        protected WTSuccessContext Context { get; }

        protected BaseRepository(WTSuccessContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}