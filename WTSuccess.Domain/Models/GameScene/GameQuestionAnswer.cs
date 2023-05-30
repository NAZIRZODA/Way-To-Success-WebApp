using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models.GameScene
{
    public class GameQuestionAnswer : EntityBase
    {
        public virtual GameQuestion? GameQuestion { get; set; }
        public ulong GameQuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
