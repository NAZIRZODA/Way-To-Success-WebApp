namespace WTSuccess.Domain.Models
{
    public class StudentExam : EntityBase
    {
        public ulong StudentId { get; set; }
        public ulong ChapterId { get; set; }
        public virtual Chapter? Chapter { get; set; }
        public virtual List<StudentAnswer>? StudentAnswers { get; set; }
    }

}
