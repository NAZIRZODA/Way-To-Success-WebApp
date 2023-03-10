using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Player:EntityBase
    {
        public ulong StudentId { get; set; }
        public bool TrueAnswer { get; set; }
        public bool FalseAnswer { get; set; }
    }
}
