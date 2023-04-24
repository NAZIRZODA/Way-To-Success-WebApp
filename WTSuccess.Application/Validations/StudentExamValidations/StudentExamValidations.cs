using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentExamRequests;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Application.Validations.StudentExamValidations
{
    public class StudentExamValidations : AbstractValidator<CreateStudentExamRequestModel>
    {
        public StudentExamValidations()
        {
            RuleFor(s=>s.ChapterId).NotEmpty().NotNull().WithMessage("Chapter id can not be null");
            RuleFor(s => s.StudentId).NotEmpty().NotNull().WithMessage("Student id can not be null");
        }
    }
}
