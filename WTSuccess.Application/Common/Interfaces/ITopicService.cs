using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface ITopicService : IBaseService<Topic, TopicResponseModel, TopicRequestModel>
    {
    }
}
