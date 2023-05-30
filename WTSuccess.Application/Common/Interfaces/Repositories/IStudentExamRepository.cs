using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentAnswerRequests;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Application.Common.Interfaces.Repositories
{
    public interface IStudentExamRepository : IRepository<StudentExam>
    {
        public string AddExamAnswers(List<StudentAnswer> createStudentAnswerRequestModels);
    }
}
