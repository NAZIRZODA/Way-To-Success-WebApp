namespace WTSuccess.Domain.Models
{
    public class Exam : EntityBase
    {
        public  List<Question> Questions { get; set; }
        public bool ExamResult { get; set; }
        public ulong StudentId { get; set; }
    }

}
