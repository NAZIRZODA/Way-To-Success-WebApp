﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.TopicRequests
{
    public class TopicRequestModel : BaseRequest
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Teory { get; set; }
    }
}
