

namespace WTSuccess.Domain.Models
{
    public class StudentExam: EntityBase
    {
        public virtual Student Student { get; set; }

        public ulong StudentId { get; set; }

        public virtual Question Question { get; set; }
        public ulong StudentAnswerId { get; set; }
        public ulong QuestionId { get; set; }
    }

}
