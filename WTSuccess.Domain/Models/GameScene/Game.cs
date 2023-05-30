using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models.GameScene
{
    public class Game : EntityBase
    {
        public ulong StudentId { get; set; }
        public ulong GamePlayerId { get; set; }
        public virtual GamePlayer GamePlayer { get; set; }
        public ulong GameQuestionId { get; set; }
        public ulong GameQuestionAnswerId { get; set; }
        public bool IsTrue { get; set; }
    }
}
