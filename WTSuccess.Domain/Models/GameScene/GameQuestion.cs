using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models.GameScene
{
    public class GameQuestion : EntityBase
    {
        public virtual Level? Level { get; set; }
        public ulong LevelWithNumberId { get; set; }
        public string Question { get; set; }
        public virtual List<GameQuestionAnswer> QuestionAnswer { get; set; } = null!;
    }
}
