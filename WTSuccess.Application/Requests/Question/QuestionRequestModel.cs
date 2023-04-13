
namespace WTSuccess.Application.Requests.Question
{
    public class QuestionRequestModel: BaseRequest
    {
        public string Text { get; set; }
        public ulong ChapterId { get; set; }
    }
}
