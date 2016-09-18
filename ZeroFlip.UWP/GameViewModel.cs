using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFlip.Lib;
using ZeroFlip.UWP.Common;

namespace ZeroFlip.UWP
{
    public class GameViewModel : ViewModelBase
    {
        ZeroGrid grid;
        public int Level { get; set; }

        public GameViewModel()
        {
            grid = new ZeroGrid(1, 5);
        }
    }
}
