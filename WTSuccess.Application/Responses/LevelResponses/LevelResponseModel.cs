using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Responses.LevelResponses
{
    public class LevelResponseModel : BaseResponse
    {
        public ulong Id { get; set; }
        public ulong LevelWithNumber { get; set; }
    }
}
