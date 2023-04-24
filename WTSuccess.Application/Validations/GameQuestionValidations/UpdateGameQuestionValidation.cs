using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.GameQuestionRequests;

namespace WTSuccess.Application.Validations.GameQuestionValidations
{
    public class UpdateGameQuestionValidation : AbstractValidator<UpdateGameQuestionRequestModel>
    {
        public UpdateGameQuestionValidation()
        {
            RuleFor(s => s.QuestionAnswer.Count(c => c.IsCorrect)).Equal(1).WithMessage("You can add only one true answer");
            RuleFor(s => s.QuestionAnswer.Count(c => !c.IsCorrect)).Equal(3).WithMessage("You need to add three incorrect answer");
            RuleFor(s => s.QuestionAnswer.Count()).GreaterThan(3).LessThan(5);
        }

    }
}
