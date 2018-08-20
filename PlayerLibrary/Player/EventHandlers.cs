using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLibrary.Player
{
    public class PlayEventArgs : EventArgs
    {
        public PlayEventArgs(double duration, double position)
        {
            Duration = duration;
            Position = position;
        }
        public double Duration { get; set; }
        public double Position { get; set; }
    }
}
