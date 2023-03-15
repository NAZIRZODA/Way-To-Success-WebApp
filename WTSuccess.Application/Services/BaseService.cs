using AutoMapper;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.RequestModels;
using WTSuccess.Application.ResponseModels;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public abstract class
        BaseService<TEntity, TResponseModel, TRequestModel> : IBaseService<TEntity, TResponseModel, TRequestModel>
        where TEntity : EntityBase
        where TResponseModel : BaseResponseModel
        where TRequestModel : BaseRequestModel
    {
        protected IBaseRepository<TEntity> Repository;
        protected IMapper Mapper { get; }

        protected BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual void Add(TRequestModel request)
        {
            var entity = Mapper.Map<TRequestModel, TEntity>(request);
            entity.CreateAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            Repository.Add(entity);
        }

        public void Delete(ulong id)
        {
            Repository.Delete(id);
        }

        public virtual TResponseModel GetById(ulong id)
        {
            return Mapper.Map<TEntity, TResponseModel>(Repository.GetById(id));
        }

        public void Update(TRequestModel request, ulong id)
        {
            var entity = Mapper.Map<TRequestModel, TEntity>(request);
            entity.UpdatedAt = DateTime.Now;
            Repository.Update(entity);
        }
    }
}