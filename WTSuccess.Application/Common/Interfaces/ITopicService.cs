using WTSuccess.Application.RequestModels.TopicRequestModels;
using WTSuccess.Application.ResponseModels.TopicResponseModels;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface ITopicService : IBaseService<Topic, TopicResponseModel, TopicRequestModel>
    {
    }
}