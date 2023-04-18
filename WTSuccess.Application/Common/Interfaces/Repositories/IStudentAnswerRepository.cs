using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Common.Interfaces.Repositories
{
    public interface IStudentAnswerRepository : IRepository<StudentAnswer>
    {
        public bool CheckForDuplicateAnswers(CreateStudentAnswerRequestModel createStudentAnswerRequestModel);
    }
}
