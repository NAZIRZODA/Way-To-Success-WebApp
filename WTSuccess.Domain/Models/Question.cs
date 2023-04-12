
namespace WTSuccess.Domain.Models
{
    public class Question: EntityBase
    {
        public string Text { get; set; }

        public virtual List<Answer> Answers { get; set; }

        public ulong CorrectAnswerId { get; set; }

        public virtual Chapter? Chapter { get; set; }

        public ulong ChapterId { get; set; }
    }
}
