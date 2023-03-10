using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Context;
using WTSuccess.Domain.Models;

namespace WTSuccess.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
 
        virtual public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        virtual public void Delete(T entity, ulong id)
        {
            throw new NotImplementedException();
        }

        virtual public T GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        virtual public void Update(T entity, ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
