using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.GameRequests;
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
    }
}
