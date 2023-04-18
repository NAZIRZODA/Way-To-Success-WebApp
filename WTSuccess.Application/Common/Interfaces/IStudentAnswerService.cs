using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Application.Responses.StudentAnswerResponses;
using WTSuccess.Application.Responses.StudentExamRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IStudentAnswerService : IBaseService<StudentAnswer, StudentAnswerResponseModel, StudentAnswerRequestModel>
    {
    }
}
