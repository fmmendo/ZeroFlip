using Mendo.UWP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFlip.Lib
{
    public class Tile : ViewModelBase
    {
        public int Value { get { return GetV(0); } set { Set(value); } }

        public bool Revealed { get { return GetV(false); } set { Set(value); } }

        public bool HintZero { get { return GetV(false); } set { Set(value); } }
        public bool HintOne { get { return GetV(false); } set { Set(value); } }
        public bool HintTwo { get { return GetV(false); } set { Set(value); } }
        public bool HintThree { get { return GetV(false); } set { Set(value); } }
    }
}
