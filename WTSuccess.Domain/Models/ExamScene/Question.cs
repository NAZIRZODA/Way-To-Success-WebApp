using WTSuccess.Domain.Models.CourseScene;

namespace WTSuccess.Domain.Models.ExamScene
{
    public class Question : EntityBase
    {
        public string Text { get; set; }

        public virtual List<Answer> Answers { get; set; }

        public virtual Chapter? Chapter { get; set; }

        public ulong ChapterId { get; set; }
    }
}
