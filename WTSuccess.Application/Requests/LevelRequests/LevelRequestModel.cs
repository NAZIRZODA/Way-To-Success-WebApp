using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.LevelRequests
{
    public abstract class LevelRequestModel : BaseRequest
    {
        public ulong LevelWithNumber { get; set; }
    }
}
