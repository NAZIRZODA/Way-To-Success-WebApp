namespace WTSuccess.Domain.Models
{
    public class Chapter : EntityBase
    {
        public List<Topic> Contents { get; set; }
        public ulong ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
