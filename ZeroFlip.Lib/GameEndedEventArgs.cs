using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFlip.Lib
{
    public class GameEndedEventArgs : EventArgs
    {
        public int NextLevel { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
    }
}
