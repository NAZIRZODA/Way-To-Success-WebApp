
namespace WTSuccess.Domain.Models
{
    public class Answer: EntityBase
    {
        public string Text { get; set; }

        public Question Question { get; set; }

        public ulong QuestionId { get; set; }
    }
}
