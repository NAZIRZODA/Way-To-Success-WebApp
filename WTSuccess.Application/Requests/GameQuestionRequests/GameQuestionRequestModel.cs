﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Requests.GameQuestionRequests
{
    public abstract class GameQuestionRequestModel : BaseRequest
    {
        public ulong Level { get; set; }
        public string Question { get; set; }
        public List<GameQuestionAnswer> QuestionAnswer { get; set; }
    }
}
