using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Course : EntityBase
    {
        public string Name { get; set; }
        public List<Chapter> Catalogs { get; set; }
        public Student Student { get; set; }
        public ulong StudentId { get; set; }
    }
}
