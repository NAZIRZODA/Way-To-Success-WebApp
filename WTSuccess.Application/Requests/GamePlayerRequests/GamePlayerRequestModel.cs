using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.GamePlayerRequest
{
    public abstract class GamePlayerRequestModel : BaseRequest
    {
        public ulong FirstStudentId { get; set; }
        public ulong SecondStudentId { get; set; }
    }
}
