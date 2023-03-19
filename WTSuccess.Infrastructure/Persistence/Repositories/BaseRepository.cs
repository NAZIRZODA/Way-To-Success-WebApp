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
            Context.Set<T>().Add(entity);

        }

        public void Delete(ulong id)
        {
            var dbValue = Context.Set<T>().Find(id);
            if (dbValue != null) Context.Set<T>().Remove(dbValue);
        }

        public virtual void Update(T entity, ulong id)
        {
            throw new NotImplementedException();
        }

        public T GetById(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}