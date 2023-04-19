using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.TopicRequests;
using WTSuccess.Application.Responses.TopicResponses;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Services
{
    public class TopicService : BaseService<Topic, TopicResponseModel, TopicRequestModel>, ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _topicRepository = repository;
            _mapper = mapper;
        }

        public override TopicResponseModel Add(TopicRequestModel request)
        {
            var parsedToCreate = request as CreateTopicRequestModel;
            if (parsedToCreate == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));
            return base.Add(request);
        }

        public override TopicResponseModel Update(ulong id, TopicRequestModel request)
        {
            var dbTopic = _topicRepository.FindById(id);
            if (dbTopic == null) throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(Student));

            var topicRequestToUpdate = request as UpdateTopicRequestModel;
            var result = _mapper.Map(topicRequestToUpdate, dbTopic);
            _topicRepository.Update(dbTopic);
            _topicRepository.SaveChanges();
            return _mapper.Map<Topic, TopicResponseModel>(dbTopic);
        }

        public override IEnumerable<TopicResponseModel> GetAll(int pageList, int pageNumber)
        {
            var dbTopics = _topicRepository.GetAll(pageList, pageNumber);
            var mappedToRespones = _mapper.Map<IEnumerable<Topic>, IEnumerable<TopicResponseModel>>(dbTopics);
            return mappedToRespones;
        }
    }
}