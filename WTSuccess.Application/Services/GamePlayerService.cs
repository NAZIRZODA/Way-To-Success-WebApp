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
using WTSuccess.Application.Requests.GameQuestionRequests;
using WTSuccess.Application.Responses.GamePlayerResponses;
using WTSuccess.Application.Responses.GameQuestionResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Services
{
    public class GamePlayerService : BaseService<GamePlayer, GamePlayerResponseModel, GamePlayerRequestModel>, IGamePlayerService
    {
        private readonly IGamePlayerRepository _gamePlayerRepository;
        private readonly IMapper _mapper;

        public GamePlayerService(IGamePlayerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _gamePlayerRepository = repository;
            _mapper = mapper;
        }

        public override void Add(GamePlayerRequestModel request)
        {
            var entity = request as CreateGamePlayerRequestModel;
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedRequestToGamePlayer = _mapper.Map<CreateGamePlayerRequestModel, GamePlayer>(entity);
            _gamePlayerRepository.Add(mappedRequestToGamePlayer);
            _gamePlayerRepository.SaveChanges();
        }

        public override GamePlayerResponseModel Get(ulong id)
        {
            var entity = _gamePlayerRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToResponseGamePlayer = _mapper.Map<GamePlayer, GamePlayerResponseModel>(entity);
            return mappedToResponseGamePlayer;
        }

        public override IEnumerable<GamePlayerResponseModel> GetAll(int pageList, int pageNumber)
        {
            var entities = _gamePlayerRepository.GetAll(pageList, pageNumber);
            if (entities == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToGamePlayerToResponse = _mapper.Map<IEnumerable<GamePlayer>, IEnumerable<GamePlayerResponseModel>>(entities);
            return mappedToGamePlayerToResponse;
        }

        public override GamePlayerResponseModel Update(ulong id, GamePlayerRequestModel request)
        {
            var entity = _gamePlayerRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var gamePlayerRequestToUpdate = request as UpdateGamePlayerRequestModel;
            var updateRequestToGamePlayer = _mapper.Map(gamePlayerRequestToUpdate, entity);
            _gamePlayerRepository.Update(entity);
            _gamePlayerRepository.SaveChanges();
            return _mapper.Map<GamePlayer, GamePlayerResponseModel>(entity);
        }

        public override bool Delete(ulong id)
        {
            var entity = _gamePlayerRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            _gamePlayerRepository.Delete(entity);
            _gamePlayerRepository.SaveChanges();
            return true;
        }
    }
}
