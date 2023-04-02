using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.ExamRequests;
using WTSuccess.Application.Responses.ExamRespones;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IExamService : IBaseService<Exam, ExamResponseModel, ExamRequestModel>
    {

    }
}
