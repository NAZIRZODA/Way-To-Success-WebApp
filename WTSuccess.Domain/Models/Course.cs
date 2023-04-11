using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Exam : EntityBase
    {
        public string Name { get; set; } = null!;
        public virtual List<Chapter>? Chapters { get; set; }
        public virtual List<Student>? Students { get; set; }
    }
}
