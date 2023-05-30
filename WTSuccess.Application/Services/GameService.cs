using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.GamePlayerRequest;
using WTSuccess.Application.Requests.GameRequests;
using WTSuccess.Application.Responses.GamePlayerResponses;
using WTSuccess.Application.Responses.GameResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Services
{
    public class GameService : BaseService<Game, GameResponseModel, GameRequestModel>, IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _gameRepository = repository;
            _mapper = mapper;
        }

        public override void Add(GameRequestModel request)
        {
            var entity = request as CreateGameRequestModel;
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedRequestToGame = _mapper.Map<CreateGameRequestModel, Game>(entity);
            _gameRepository.Add(mappedRequestToGame);
            _gameRepository.SaveChanges();
        }

        public override GameResponseModel Get(ulong id)
        {
            var entity = _gameRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToResponseGame = _mapper.Map<Game, GameResponseModel>(entity);
            return mappedToResponseGame;
        }

        public override IEnumerable<GameResponseModel> GetAll(int pageList, int pageNumber)
        {
            var entities = _gameRepository.GetAll(pageList, pageNumber);
            if (entities == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToGameToResponse = _mapper.Map<IEnumerable<Game>, IEnumerable<GameResponseModel>>(entities);
            return mappedToGameToResponse;
        }

        public override GameResponseModel Update(ulong id, GameRequestModel request)
        {
            var entity = _gameRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var gameRequestToUpdate = request as UpdateGameRequestModel;
            var updateRequestToGame = _mapper.Map(gameRequestToUpdate, entity);
            _gameRepository.Update(entity);
            _gameRepository.SaveChanges();
            return _mapper.Map<Game, GameResponseModel>(entity);
        }

        public override bool Delete(ulong id)
        {
            var entity = _gameRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            _gameRepository.Delete(entity);
            _gameRepository.SaveChanges();
            return true;
        }
    }
}
