using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Responses.TopicResponses
{
    public class TopicResponseModel : BaseResponse
    {
        public string Name { get; set; }
        public string Teory { get; set; }
        public ulong ChapterId { get; set; }
    }
}
