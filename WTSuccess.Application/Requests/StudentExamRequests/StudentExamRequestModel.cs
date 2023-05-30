using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Application.Requests.StudentExamRequests
{
    public abstract class StudentExamRequestModel : BaseRequest
    {
        public ulong StudentId { get; set; }
        public ulong ChapterId { get; set; }
    }
}
