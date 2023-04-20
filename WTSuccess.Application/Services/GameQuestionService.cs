using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.GameQuestionRequests;
using WTSuccess.Application.Responses.GameQuestionResponses;
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
    }
}
