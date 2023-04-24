using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentAnswerRequests;

namespace WTSuccess.Application.Validations.StudentExamValidations
{
    public class StudentAnswerValidation : AbstractValidator<CreateStudentAnswerRequestModel>
    {
        public StudentAnswerValidation()
        {
            RuleFor(s => s.AnswerId).NotEmpty().NotNull();
            RuleFor(s => s.QuestionId).NotEmpty().NotNull();
            RuleFor(s => s.StudenExamId).NotEmpty().NotNull();
        }
    }
}
