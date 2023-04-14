
namespace WTSuccess.Application.Responses.QuestionResponses
{
    public class QuestionResponseModel: BaseResponse
    {
        public string Text { get; set; }
        public List<AnswerResponseModel> Answers { get; set; }
        public ulong ChapterId { get; set; }
        //public QuestionType QuestionType { get; set; }
    }

    //public enum QuestionType
    //{
    //    MultiAnswer,
    //    SingleAnswer
    //}
}
