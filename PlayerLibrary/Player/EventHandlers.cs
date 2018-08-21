using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLibrary.Player
{
    public class PlayEventArgs : EventArgs
    {
        public PlayEventArgs(double duration)
        {
            Duration = duration;
        }
        public double Duration { get; set; }
    }
}
