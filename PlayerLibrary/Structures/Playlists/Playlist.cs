using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLibrary.Structures.Songs;
using System.Drawing;

namespace PlayerLibrary.Structures.Playlists
{
    public class Playlist : List<Song>
    {
        /// <summary>
        /// The playlist's name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The thumbnail image of the playlist
        /// </summary>
        //public Bitmap Thumbnail { get; set; }
    }
}
