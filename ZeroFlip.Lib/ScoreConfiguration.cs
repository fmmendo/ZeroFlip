using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFlip.Lib
{
    public struct PointsConfiguration
    {
        public int Points;
        public int Twos;
        public int Threes;
    }

    public struct ScoreConfiguration
    {
        public int Level;
        public int Min;
        public int Max;
    }

    public class ScoringData
    {
        public static readonly ScoreConfiguration[] LevelMinMax = new ScoreConfiguration[]
            {
                new ScoreConfiguration { Level = 0, Min=0, Max=18 },
                new ScoreConfiguration { Level = 1, Min=24, Max=48 },
                new ScoreConfiguration { Level = 2, Min=54, Max=96 },
                new ScoreConfiguration { Level = 3, Min=108, Max=192 },
                new ScoreConfiguration { Level = 4, Min=216, Max=324 },
                new ScoreConfiguration { Level = 5, Min=384, Max=576 },
                new ScoreConfiguration { Level = 6, Min=648, Max=972 },
                new ScoreConfiguration { Level = 9, Min=1024, Max=1536 },
                new ScoreConfiguration { Level = 8, Min=1728, Max=2592 },
                new ScoreConfiguration { Level = 9, Min=2916, Max=5184 },
                new ScoreConfiguration { Level = 10, Min=5832, Max=11664 },
            };

        public static readonly PointsConfiguration[] ScoreList = new PointsConfiguration[]
            {
                new PointsConfiguration { Points = 1, Twos = 0, Threes = 0 },
                new PointsConfiguration { Points = 2, Twos = 1, Threes = 0 },
                new PointsConfiguration { Points = 3, Twos = 0, Threes = 1 },
                new PointsConfiguration { Points = 4, Twos = 2, Threes = 0 },
                new PointsConfiguration { Points = 6, Twos = 1, Threes = 1 },
                new PointsConfiguration { Points = 8, Twos = 3, Threes = 0 },
                new PointsConfiguration { Points = 9, Twos = 0, Threes = 2 },
                new PointsConfiguration { Points = 12, Twos = 2, Threes = 1 },
                new PointsConfiguration { Points = 16, Twos = 4, Threes = 0 },
                new PointsConfiguration { Points = 18, Twos = 1, Threes = 2 },

                new PointsConfiguration { Points = 24, Twos = 3, Threes = 1 },
                new PointsConfiguration { Points = 27, Twos = 0, Threes = 3 },
                new PointsConfiguration { Points = 32, Twos = 5, Threes = 0 },
                new PointsConfiguration { Points = 36, Twos = 2, Threes = 2 },
                new PointsConfiguration { Points = 48, Twos = 4, Threes = 1 },

                new PointsConfiguration { Points = 54, Twos = 1, Threes = 3 },
                new PointsConfiguration { Points = 64, Twos = 6, Threes = 0 },
                new PointsConfiguration { Points = 72, Twos = 3, Threes = 2 },
                new PointsConfiguration { Points = 81, Twos = 0, Threes = 4 },
                new PointsConfiguration { Points = 96, Twos = 5, Threes = 1 },

                new PointsConfiguration { Points = 108, Twos = 2, Threes = 3 },
                new PointsConfiguration { Points = 128, Twos = 7, Threes = 0 },
                new PointsConfiguration { Points = 144, Twos = 4, Threes = 2 },
                new PointsConfiguration { Points = 162, Twos = 1, Threes = 4 },
                new PointsConfiguration { Points = 192, Twos = 6, Threes = 1 },

                new PointsConfiguration { Points = 216, Twos = 3, Threes = 3 },
                new PointsConfiguration { Points = 243, Twos = 0, Threes = 5 },
                new PointsConfiguration { Points = 256, Twos = 8, Threes = 0 },
                new PointsConfiguration { Points = 288, Twos = 5, Threes = 2 },
                new PointsConfiguration { Points = 324, Twos = 2, Threes = 4 },

                new PointsConfiguration { Points = 384, Twos = 7, Threes = 1 },
                new PointsConfiguration { Points = 432, Twos = 4, Threes = 3 },
                new PointsConfiguration { Points = 486, Twos = 1, Threes = 5 },
                new PointsConfiguration { Points = 512, Twos = 9, Threes = 0 },
                new PointsConfiguration { Points = 576, Twos = 6, Threes = 2 },

                new PointsConfiguration { Points = 648, Twos = 3, Threes = 4 },
                new PointsConfiguration { Points = 729, Twos = 0, Threes = 6 },
                new PointsConfiguration { Points = 768, Twos = 8, Threes = 1 },
                new PointsConfiguration { Points = 864, Twos = 5, Threes = 3 },
                new PointsConfiguration { Points = 972, Twos = 2, Threes = 5 },

                new PointsConfiguration { Points = 1024, Twos = 10, Threes = 0 },
                new PointsConfiguration { Points = 1152, Twos = 7, Threes = 2 },
                new PointsConfiguration { Points = 1296, Twos = 4, Threes = 4 },
                new PointsConfiguration { Points = 1458, Twos = 1, Threes = 6 },
                new PointsConfiguration { Points = 1536, Twos = 9, Threes = 1 },

                new PointsConfiguration { Points = 1728, Twos = 6, Threes = 3 },
                new PointsConfiguration { Points = 1944, Twos = 3, Threes = 5 },
                new PointsConfiguration { Points = 2187, Twos = 0, Threes = 7 },
                new PointsConfiguration { Points = 2304, Twos = 8, Threes = 2 },
                new PointsConfiguration { Points = 2592, Twos = 5, Threes = 4 },

                new PointsConfiguration { Points = 2916, Twos = 2, Threes = 6 },
                new PointsConfiguration { Points = 3456, Twos = 7, Threes = 3 },
                new PointsConfiguration { Points = 3888, Twos = 4, Threes = 5 },
                new PointsConfiguration { Points = 4374, Twos = 1, Threes = 7 },
                new PointsConfiguration { Points = 5184, Twos = 6, Threes = 4 },

                new PointsConfiguration { Points = 5832, Twos = 3, Threes = 6 },
                new PointsConfiguration { Points = 6561, Twos = 0, Threes = 8 },
                new PointsConfiguration { Points = 7776, Twos = 5, Threes = 5 },
                new PointsConfiguration { Points = 8748, Twos = 2, Threes = 7 },
                new PointsConfiguration { Points = 11664, Twos = 4, Threes = 6 },

                new PointsConfiguration { Points = 13122, Twos = 1, Threes = 8 },
                new PointsConfiguration { Points = 17496, Twos = 3, Threes = 7 },
                new PointsConfiguration { Points = 19683, Twos = 0, Threes = 9 },
                new PointsConfiguration { Points = 26244, Twos = 2, Threes = 8 },
                new PointsConfiguration { Points = 39366, Twos = 1, Threes = 9 },
                new PointsConfiguration { Points = 59049, Twos = 0, Threes = 10 }
            };
    }
}
