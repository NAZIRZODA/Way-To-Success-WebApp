using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models.GameScene
{
    public class Level : EntityBase
    {
        public virtual List<GameQuestion>? GameQuestion { get; set; }
        public ulong LevelWithNumber { get; set; }
    }
}
