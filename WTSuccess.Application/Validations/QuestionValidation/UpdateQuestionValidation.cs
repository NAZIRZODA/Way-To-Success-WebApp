using FluentValidation;
using WTSuccess.Application.Requests.Question;

namespace WTSuccess.Application.Validations.QuestionValidation
{
    public class UpdateQuestionValidation: AbstractValidator<UpdateQuestionRequestModel>
    {
        public UpdateQuestionValidation()
        {
            RuleFor(q => q.Text).NotNull().NotEmpty();
        }
    }
}
