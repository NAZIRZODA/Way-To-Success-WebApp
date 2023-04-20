using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models.GameScene
{
    public class GameQuestion : EntityBase
    {
        public ulong Level { get; set; }
        public string Question { get; set; }
        public List<GameQuestionAnswer> QuestionAnswer { get; set; }
    }

    enum Level
    {
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10
    }
}
