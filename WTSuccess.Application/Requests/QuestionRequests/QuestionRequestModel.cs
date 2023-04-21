
namespace WTSuccess.Application.Requests.Question
{
    public abstract class QuestionRequestModel : BaseRequest
    {
        public string Text { get; set; }
        public ulong ChapterId { get; set; }
        public List<CreateAnswerRequestModel> Answers { get; set; }
    }
}
