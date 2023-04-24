using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Responses.GameQuestionResponses
{
    public class GameQuestionResponseModel : BaseResponse
    {
        public ulong LevelWithNumberId { get; set; }
        public string Question { get; set; }
        public List<GameQuestionAnswerResponseModel> QuestionAnswer { get; set; }
    }
}
