using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Responses.GameQuestionResponses
{
    public class GameQuestionAnswerResponseModel : BaseResponse
    {
        public ulong Id { get; set; }
        public string Text { get; set; }
    }
}
