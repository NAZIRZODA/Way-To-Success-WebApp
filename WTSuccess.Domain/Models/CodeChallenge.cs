using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class CodeChallenge : EntityBase
    {
        public Player[] Player { get; set; } = new Player[2];
        public List<Course> Languages { get; set; }
        public List<Student> Students { get; set; }
        public int Point { get; set; }
    }
}
