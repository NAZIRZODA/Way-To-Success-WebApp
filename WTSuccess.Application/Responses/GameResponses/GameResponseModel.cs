using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Responses.GameResponses
{
    public class GameResponseModel : BaseResponse
    {
        public ulong StudentId { get; set; }
        public ulong GamePlayerId { get; set; }
        public ulong GameQuestionId { get; set; }
        public ulong GameQuestionAnswerId { get; set; }
    }
}
