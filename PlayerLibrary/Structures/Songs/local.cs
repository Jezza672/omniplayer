using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLibrary.Structures.Songs
{
    /// <summary>
    /// The local song class. Inherits Song.
    /// </summary>
    public class Local : Song
    {
        /// <summary>
        /// Initializes a new instance of the Local class.
        /// </summary>
        /// <param name="url">Url to the file.</param>
        public Local(string url)
        {
            Title = url;
            Artist = "Artist";
            Album = "Album";
            TrackNumber = 0;
            DiscNumber = 0;
            Genre = "Genre";
            Duration = 1;
            Location = url;
        }
    }
}
