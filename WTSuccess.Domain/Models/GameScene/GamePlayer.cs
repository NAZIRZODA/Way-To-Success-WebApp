using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models.GameScene
{
    public class GamePlayer : EntityBase
    {
        public ulong FirstStudentId { get; set; }
        public ulong SecondStudentId { get; set; }
        public ulong WinnerStudentId { get; set; }
        public virtual List<Game>? Games { get; set; }
    }
}
