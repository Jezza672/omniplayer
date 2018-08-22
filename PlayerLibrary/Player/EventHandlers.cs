using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLibrary.Structures.Songs;

namespace PlayerLibrary.Player
{
    public class PlayEventArgs : EventArgs
    {
        public PlayEventArgs(double duration, Song song)
        {
            Duration = duration;
            Song = song;
        }
        public double Duration { get; set; }
        public Song Song { get; set; }
    }
}
