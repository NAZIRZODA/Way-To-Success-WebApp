using AutoMapper;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests;
using WTSuccess.Application.Responses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public abstract class BaseService<TEntity, TResponseModel, TRequestModel> : IBaseService<TEntity, TResponseModel, TRequestModel>
        where TEntity : EntityBase
        where TResponseModel : BaseResponse
        where TRequestModel : BaseRequest
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual TResponseModel Add(TRequestModel request)
        {
            var entity = _mapper.Map<TRequestModel, TEntity>(request);
            _repository.Add(entity);
            _repository.SaveChanges();
            return _mapper.Map<TEntity, TResponseModel>(entity);
        }

        public virtual bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public virtual TResponseModel Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TResponseModel> GetAll(int pageList, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public virtual TResponseModel Update(ulong id, TRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
