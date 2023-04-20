
using WTSuccess.Application.Requests.Question;
using WTSuccess.Application.Responses.QuestionResponses;
using WTSuccess.Domain.Models.ExamScene;

namespace WTSuccess.Application.Common.Interfaces
{
    public interface IQuestionService: IBaseService<Question, QuestionResponseModel, QuestionRequestModel>
    {
    }
}
