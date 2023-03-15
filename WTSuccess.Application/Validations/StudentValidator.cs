using FluentValidation;
using WTSuccess.Application.RequestModels;
using WTSuccess.Application.RequestModels.StudentRequestModels;
using WTSuccess.Application.ResponseModels.StudentResponseModels.cs;
using WTSuccess.Domain.Models;

namespace WTSuccess.Application.Validations;

public class CreateStudentValidator:  AbstractValidator<CreateStudentRequestModel> 
{
    public CreateStudentValidator() 
    {
        RuleFor(x => x.Name).Length(0, 10);
        RuleFor(x => x.Email).EmailAddress();
    }
}