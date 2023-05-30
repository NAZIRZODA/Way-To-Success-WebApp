using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.Question;

namespace WTSuccess.Application.Validations.QuestionValidations
{
    public class UpdateQuestionValidation : AbstractValidator<UpdateQuestionRequestModel>
    {
        public UpdateQuestionValidation()
        {
            RuleFor(s => s.Answers.Count(a => a.isCorrect)).Equal(1).WithMessage("You can add only one correct answer");
            RuleFor(s => s.Answers.Count(a => !a.isCorrect)).Equal(3).WithMessage("You need to add three incorrect answers");
            RuleFor(a => a.Answers.Count()).GreaterThan(3).LessThan(5).WithMessage("Answer need to Add 4");
        }
    }
}
