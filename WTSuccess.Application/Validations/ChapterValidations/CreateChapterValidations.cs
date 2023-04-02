using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.ChapterRequests;

namespace WTSuccess.Application.Validations.ChapterValidations
{
    public class CreateChapterValidations : AbstractValidator<CreateChapterRequestModel>
    {
        public CreateChapterValidations()
        {
            RuleFor(chap => chap.Name).NotNull().NotEmpty();
            RuleFor(chap => chap.Students).NotEmpty().NotNull();
        }
    }
}
