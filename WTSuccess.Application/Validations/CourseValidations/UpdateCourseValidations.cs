using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.CourseRequests;

namespace WTSuccess.Application.Validations.CourseValidations
{
    public class UpdateCourseValidations : AbstractValidator<UpdateCourseRequestModel>
    {
        public UpdateCourseValidations()
        {
            RuleFor(n => n.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(30);
        }
    }
}
