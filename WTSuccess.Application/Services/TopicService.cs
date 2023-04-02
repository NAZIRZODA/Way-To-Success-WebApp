using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class TopicService : BaseService<Topic, TopicResponseModel, TopicRequestModel>, ITopicService
    {
        public TopicService(IRepository<Topic> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
