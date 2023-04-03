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
        private readonly IRepository<Topic> _repository;
        private readonly IMapper _mapper;
        public TopicService(IRepository<Topic> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override void Add(TopicRequestModel request)
        {
            var parsedToCreate = request as CreateTopicRequestModel;
            if (parsedToCreate == null) throw new ArgumentNullException(nameof(Topic));
            var mappedToTopic = _mapper.Map<CreateTopicRequestModel, Topic>(parsedToCreate);
            _repository.Add(mappedToTopic);
            _repository.SaveChanges();
        }

        public override TopicResponseModel Update(ulong id, TopicRequestModel request)
        {
            var dbTopic = _repository.FindById(id);
            if (dbTopic == null) throw new ArgumentNullException(nameof(Topic));
            var topicRequestToUpdate = request as UpdateTopicRequestModel;
            dbTopic.Teory = topicRequestToUpdate.Teory;
            dbTopic.ChapterId = topicRequestToUpdate.ChapterId;
            _repository.Update(dbTopic);
            _repository.SaveChanges();
            return _mapper.Map<UpdateTopicRequestModel, TopicResponseModel>(topicRequestToUpdate);
        }

        public override TopicResponseModel Get(ulong id)
        {
            var dbTopic = _repository.FindById(id);
            if (dbTopic == null) throw new ArgumentNullException(nameof(Topic));
            var mappedToResponse = _mapper.Map<Topic, TopicResponseModel>(dbTopic);
            return mappedToResponse;
        }

        public override IEnumerable<TopicResponseModel> GetAll(int pageList, int pageNumber)
        {
            var dbTopics = _repository.GetAll(pageList, pageNumber);
            var mappedToRespones = _mapper.Map<IEnumerable<Topic>, IEnumerable<TopicResponseModel>>(dbTopics);
            return mappedToRespones;
        }

        public override bool Delete(ulong id)
        {
            var dbTopic = _repository.FindById(id);
            if (dbTopic == null) throw new ArgumentNullException(nameof(Topic));
            _repository.Delete(dbTopic);
            _repository.SaveChanges();
            return true;
        }

    }
}
