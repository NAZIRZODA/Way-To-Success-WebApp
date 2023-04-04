using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Requests.TopicRequests
{
    public class TopicRequestModel : BaseRequest
    {
        public string Teory { get; set; }
        //public Chapter Chapter { get; set; }
        public ulong ChapterId { get; set; }
    }
}
