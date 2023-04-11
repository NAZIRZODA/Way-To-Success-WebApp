using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.ChapterRequests;

namespace WTSuccess.Application.Validations.ChapterValidations
{
    public class UpdateChapterValidations : AbstractValidator<UpdateChapterRequestModel>
    {
        public UpdateChapterValidations()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty().WithMessage("Name can not be null!");
            RuleFor(n => n.Name).MinimumLength(3).MaximumLength(40).WithMessage("Min character 3 max 40");
            RuleFor(cid => cid.CourseId).NotEmpty().NotNull().WithMessage("write a course id, without course Chapter can not made!");
        }
    }
}
