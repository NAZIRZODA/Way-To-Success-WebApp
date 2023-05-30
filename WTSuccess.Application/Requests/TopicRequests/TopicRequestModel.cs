using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Requests.TopicRequests
{
    public abstract class TopicRequestModel : BaseRequest
    {
        public string Name { get; set; }
        public string Teory { get; set; }
        public ulong ChapterId { get; set; }
    }
}
