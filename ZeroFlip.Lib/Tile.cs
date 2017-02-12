using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFlip.Lib
{
    public class Tile
    {
        public int Value { get; set; }

        public bool Revealed { get; set; }

        public bool HintZero { get; set; }
        public bool HintOne { get; set; }
        public bool HintTwo { get; set; }
        public bool HintThree { get; set; }
    }
}
