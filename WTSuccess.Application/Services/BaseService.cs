using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual void Add(TEntity entity)
        {
           _repository.Add(entity);
        }

        public void Delete(TEntity entity, ulong id)
        {
           _repository.Delete(entity, id);
        }

        public TEntity GetById(ulong id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity entity, ulong id)
        {
            _repository.Update(entity, id);
        }
    }
}
