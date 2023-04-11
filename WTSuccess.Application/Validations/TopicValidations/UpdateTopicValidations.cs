using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Requests.TopicRequests;

namespace WTSuccess.Application.Validations.TopicValidations
{
    public class UpdateTopicValidations : AbstractValidator<UpdateTopicRequestModel>
    {
        public UpdateTopicValidations()
        {
            RuleFor(n => n.Name).NotEmpty().NotNull().WithMessage("Name can not be null!");
            RuleFor(n => n.Name).MinimumLength(3).MaximumLength(30).WithMessage("Name's min character 3 max 30!");
            RuleFor(t => t.Teory).NotEmpty().NotNull().WithMessage("Theory can not be null!");
            RuleFor(n => n.Name).MinimumLength(50).MaximumLength(500).WithMessage("Theory's min character 3 max 30!");
            RuleFor(chid => chid.ChapterId).NotNull().NotEmpty().WithMessage("Topic can not made without Chapter, please insert chapter id");
        }
    }
}
