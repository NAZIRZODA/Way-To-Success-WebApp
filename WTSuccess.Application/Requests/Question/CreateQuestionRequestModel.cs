

namespace WTSuccess.Application.Requests.Question
{
    public class CreateQuestionRequestModel : QuestionRequestModel
    {
        public List<CreateAnswerRequestModel> Answers { get; set; }
    }
}