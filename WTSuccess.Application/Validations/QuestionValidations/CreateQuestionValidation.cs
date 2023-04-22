using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.Question;
using WTSuccess.Domain.Models;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Application.Validations.QuestionValidations
{
    public class CreateQuestionValidation : AbstractValidator<CreateQuestionRequestModel>
    {
        public CreateQuestionValidation()
        {
            var s = RuleFor(s => s.Answers.All(s => s.isCorrect == false)).Equal(false).WithMessage("you can not add 4 false answer");
            RuleFor(s => s.Answers.All(s => s.isCorrect == true)).Equal(false).WithMessage("you can add only one true answer");
            RuleFor(a => a.Answers.Count()).GreaterThan(3).LessThan(5).WithMessage("Answer need to Add 4");
        }
    }
}
