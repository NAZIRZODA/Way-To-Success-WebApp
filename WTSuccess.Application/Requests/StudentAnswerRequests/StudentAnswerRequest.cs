using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.StudentAnswerRequests
{
    public abstract class StudentAnswerRequestModel : BaseRequest
    {
        public ulong StudenExamId { get; set; }
        public ulong QuestionId { get; set; }
        public ulong AnswerId { get; set; }
    }
}
