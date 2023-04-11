using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.StudentRequests;

namespace WTSuccess.Application.Validations.StudentValidations
{
    public class CreateStudentValidations : AbstractValidator<CreateStudentRequestModel>
    {
        public CreateStudentValidations()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().WithMessage("Name can not be null or empty!");
            RuleFor(s => s.Surname).NotEmpty().NotNull().WithMessage("Surname can not be null or empty!");
            RuleFor(s => s.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Email address type is wrong!");
            RuleFor(p => p.Password).NotEqual(s => s.Surname).WithMessage("Password can not be equal with Surname!");
            RuleFor(p => p.Password).NotEqual(s => s.Name).WithMessage("Password can not be equal with Name!");
            RuleFor(p => p.Password).NotEqual(e => e.Email).WithMessage("Password can not be equal with Email!");
            RuleFor(p => p.Password).MinimumLength(8).MaximumLength(32).WithMessage("Min character is 8 max 32");
        }
    }
}
