using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Catalog : EntityBase
    {
        public List<Content> Contents { get; set; }
        public Exam Exam { get; set; }
    }
}
