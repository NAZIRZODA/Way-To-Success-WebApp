using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.LevelRequests;
using WTSuccess.Application.Responses.LevelResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface ILevelService : IBaseService<Level, LevelResponseModel, LevelRequestModel>
    {
    }
}
