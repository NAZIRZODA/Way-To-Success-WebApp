using FluentValidation;
using WTSuccess.Application.Requests.Question;

namespace WTSuccess.Application.Validations.QuestionValidation
{
    public class CreateQuestionValidation : AbstractValidator<CreateQuestionRequestModel>
    {
        public CreateQuestionValidation()
        {
            RuleFor(q => q.Text).NotNull().NotEmpty();
            RuleFor(q => q.Answers).NotNull().NotEmpty();
        }
    }
}
