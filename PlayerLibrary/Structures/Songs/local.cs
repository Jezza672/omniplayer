using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayerLibrary.Structures.Songs
{
    public class Local : Song
    {
        public Local(string url)
        {
            Title = url;
            Artist = "Artist";
            Album = "Album";
            TrackNumber = 0;
            DiscNumber = 0;
            Genre = "Genre";
            Location = url;
        }
    }
}
