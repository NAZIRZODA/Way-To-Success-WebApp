using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.GameQuestionRequests
{
    public class CreateGameQuestionAnswerRequestModel : BaseRequest
    {
        public ulong GameQuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
