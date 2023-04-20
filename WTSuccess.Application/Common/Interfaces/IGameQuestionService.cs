using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.GameQuestionRequests;
using WTSuccess.Application.Responses.GameQuestionResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IGameQuestionService : IBaseService<GameQuestion, GameQuestionResponseModel, GameQuestionRequestModel>
    {
    }
}
