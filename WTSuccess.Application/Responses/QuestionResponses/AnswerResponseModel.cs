
namespace WTSuccess.Application.Responses.QuestionResponses
{
    public class AnswerResponseModel: BaseResponse
    {
        public string Text { get; set; }

        public bool isCorrect { get; set; }
    }
}
