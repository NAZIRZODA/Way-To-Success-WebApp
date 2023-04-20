using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.GamePlayerRequest;
using WTSuccess.Application.Responses.GamePlayerResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IGamePlayerService: IBaseService<GamePlayer, GamePlayerResponseModel, GamePlayerRequestModel>
    {
    }
}
