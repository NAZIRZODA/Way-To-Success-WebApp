using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Chapter : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Topic>? Topics { get; set; }
        public virtual Exam? Course { get; set; } = null!;
        public ulong CourseId { get; set; }
    }
}
