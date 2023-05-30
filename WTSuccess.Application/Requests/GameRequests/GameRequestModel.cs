using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.GameRequests
{
    public abstract class GameRequestModel : BaseRequest
    {
        public ulong StudentId { get; set; }
        public ulong GamePlayerId { get; set; }
        public ulong GameQuestionId { get; set; }
        public ulong GameQuestionAnswerId { get; set; }
    }
}
