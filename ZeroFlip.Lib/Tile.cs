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

        public bool Revealed
        {
            get { return GetV(false); }
            set
            {
                Set(value);

                OnPropertyChanged(nameof(HintZero));
                OnPropertyChanged(nameof(HintOne));
                OnPropertyChanged(nameof(HintTwo));
                OnPropertyChanged(nameof(HintThree));
            }
        }

        public bool HintZero { get { return Revealed ? false : GetV(false); } set { Set(value); } }
        public bool HintOne { get { return Revealed ? false : GetV(false); } set { Set(value); } }
        public bool HintTwo { get { return Revealed ? false : GetV(false); } set { Set(value); } }
        public bool HintThree { get { return Revealed ? false : GetV(false); } set { Set(value); } }
    }
}
