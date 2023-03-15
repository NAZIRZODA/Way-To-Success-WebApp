using WTSuccess.Application.RequestModels;
using WTSuccess.Application.ResponseModels;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IBaseService<TEntity, TResponseModel, TRequestModel>
        where TEntity : EntityBase
        where TResponseModel : BaseResponseModel
        where TRequestModel : BaseRequestModel
    {
        void Add(TRequestModel request);
        void Delete(ulong id);
        void Update(TRequestModel entity, ulong id);
        TResponseModel GetById(ulong id);
    }
}