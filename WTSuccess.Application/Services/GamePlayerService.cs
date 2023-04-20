using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.GamePlayerRequest;
using WTSuccess.Application.Responses.GamePlayerResponses;
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
    }
}
