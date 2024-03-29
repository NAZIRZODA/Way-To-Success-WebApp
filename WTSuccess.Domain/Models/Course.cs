﻿

namespace WTSuccess.Domain.Models
{
    public class Course : EntityBase
    {
        public string Name { get; set; } = null!;
        public virtual List<Chapter>? Chapters { get; set; }
        public virtual List<Student>? Students { get; set; }
    }
}
