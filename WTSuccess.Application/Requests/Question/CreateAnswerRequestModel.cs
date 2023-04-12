
namespace WTSuccess.Application.Requests.Question
{
    public class CreateAnswerRequestModel
    {
        public ulong Id { get; set; }
        public string Text { get; set; }
        public bool isCorrect { get; set; }
    }
}
