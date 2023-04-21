using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.GameQuestionRequests;
using WTSuccess.Application.Requests.LevelRequests;
using WTSuccess.Application.Responses.GameQuestionResponses;
using WTSuccess.Application.Responses.LevelResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Services
{
    public class GameQuestionService : BaseService<GameQuestion, GameQuestionResponseModel, GameQuestionRequestModel>, IGameQuestionService
    {
        private readonly IGameQuestionRepository _gameQuestionRepository;
        private readonly IMapper _mapper;

        public GameQuestionService(IGameQuestionRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _gameQuestionRepository = repository;
            _mapper = mapper;
        }

        public override void Add(GameQuestionRequestModel request)
        {
            var entity = request as CreateGameQuestionRequestModel;
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedRequestToQuestion = _mapper.Map<CreateGameQuestionRequestModel, GameQuestion>(entity);
            _gameQuestionRepository.Add(mappedRequestToQuestion);
            _gameQuestionRepository.SaveChanges();
        }

        public override GameQuestionResponseModel Get(ulong id)
        {
            var entity = _gameQuestionRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToResponseGameQuestion = _mapper.Map<GameQuestion, GameQuestionResponseModel>(entity);
            return mappedToResponseGameQuestion;
        }

        public override IEnumerable<GameQuestionResponseModel> GetAll(int pageList, int pageNumber)
        {
            var entities = _gameQuestionRepository.GetAll(pageList, pageNumber);
            if (entities == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToGameQuestionToResponse = _mapper.Map<IEnumerable<GameQuestion>, IEnumerable<GameQuestionResponseModel>>(entities);
            return mappedToGameQuestionToResponse;
        }

        public override GameQuestionResponseModel Update(ulong id, GameQuestionRequestModel request)
        {
            var entity = _gameQuestionRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var gameQuestionRequestToUpdate = request as UpdateGameQuestionRequestModel;
            var updateRequestToLevel = _mapper.Map(gameQuestionRequestToUpdate, entity);
            _gameQuestionRepository.Update(entity);
            _gameQuestionRepository.SaveChanges();
            return _mapper.Map<GameQuestion, GameQuestionResponseModel>(entity);
        }

        public override bool Delete(ulong id)
        {
            var entity = _gameQuestionRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            _gameQuestionRepository.Delete(entity);
            _gameQuestionRepository.SaveChanges();
            return true;
        }
    }
}
