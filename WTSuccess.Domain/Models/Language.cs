using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Language:EntityBase
    {
        public string Name { get; set; }
        public List<Catalog> Catalogs { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
