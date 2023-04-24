using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Application.Requests.StudentExamRequests;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Application.Responses.StudentExamRespones;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IStudentExamService : IBaseService<StudentExam, StudentExamResponseModel, StudentExamRequestModel>
    {
        public IEnumerable<QuestionResponseModel> GetQuestions(ulong studentExamId);
        public string AddExamAnswers(List<CreateStudentAnswerRequestModel> createStudentAnswerRequestModels);
    }
}
