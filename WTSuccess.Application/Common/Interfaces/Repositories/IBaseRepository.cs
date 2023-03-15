using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        void Delete(ulong id);
        void Update(TEntity entity);
        TEntity GetById(ulong id);
    }
}
