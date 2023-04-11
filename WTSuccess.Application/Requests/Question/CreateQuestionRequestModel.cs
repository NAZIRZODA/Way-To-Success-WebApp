

namespace WTSuccess.Application.Requests.Question
{
    public class CreateQuestionRequestModel
    {
        public string Text { get; set; }

        public ulong ChapterId { get; set; }

        public List<CreateAnswerRequestModel> CreateAnswerRequestModels { get; set; }
    }
}