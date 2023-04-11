
namespace WTSuccess.Application.Requests.Question
{
    public class QuestionRequestModel: BaseRequest
    {
        public ulong Id { get; set; }
        public string Text { get; set; }
        public ulong ChapterId { get; set; }
    }
}
