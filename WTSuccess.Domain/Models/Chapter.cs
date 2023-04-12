
namespace WTSuccess.Domain.Models
{
    public class Chapter : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Topic>? Topics { get; set; }
        public virtual Course? Course { get; set; } = null!;
        public ulong CourseId { get; set; }
        public virtual List<Question>? Questions { get; set; }
    }
}
