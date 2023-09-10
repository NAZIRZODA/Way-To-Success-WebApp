
namespace WTSuccess.Application.Responses.QuestionResponses
{
    public class QuestionResponseModel: BaseResponse
    {
        public ulong Id { get; set; }
        public string Text { get; set; }
        public List<AnswerResponseModel> Answers { get; set; }
        public ulong ChapterId { get; set; }
    }
}
