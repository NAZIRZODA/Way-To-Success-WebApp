

namespace WTSuccess.Domain.Models
{
    public class StudentExam : EntityBase
    {
        public ulong StudentId { get; set; }
        public ulong ChapterId { get; set; }

        //response
        public virtual Question Question { get; set; }


    }

}
