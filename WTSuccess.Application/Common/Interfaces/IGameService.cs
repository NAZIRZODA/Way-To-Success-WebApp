using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Requests.GameRequests;
using WTSuccess.Application.Responses.GameResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IGameService : IBaseService<Game, GameResponseModel, GameRequestModel>
    {
    }
}
