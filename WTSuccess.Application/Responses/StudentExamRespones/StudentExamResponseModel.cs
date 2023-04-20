using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Application.Responses.StudentExamRespones
{
    public class StudentExamResponseModel : BaseResponse
    {
        public Question Question { get; set; }
    }
}
