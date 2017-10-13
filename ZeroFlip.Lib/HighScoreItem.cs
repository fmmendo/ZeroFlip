using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFlip.Lib
{
    public class HighScores
    {
        public List<HighScoreItem> Table { get; set; }
    }

    public class HighScoreItem
    {
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
