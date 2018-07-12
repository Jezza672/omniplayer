using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLibrary.Structures.Songs;

namespace PlayerLibrary.Structures.Playlists
{
    /// <summary>
    /// The playlist class (inherits List of Song).
    /// </summary>
    public class Playlist : List<Song>
    {
        /// <summary>
        /// Gets or sets the playlist's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the duration of the playlist.
        /// </summary>
        public float Duration
        {
            get
            {
                return this.Sum(i => i.Duration);
            }
        }

        /// <summary>
        /// The thumbnail image of the playlist.
        /// </summary>
        ////public Bitmap Thumbnail { get; set; }

        /// <summary>
        /// Initializes a new instance of the Playlist class.
        /// </summary>
        /// <param name="name">The name of the playlist</param>
        public Playlist(string name = "default")
        {
            Name = name;
        }

        /// <summary>
        /// Create a new playlist filled with songs from a folder.
        /// </summary>
        /// <param name="url">The url of the folder.</param>
        /// <param name="name">The name of the playlist being created.</param>
        /// <returns>The new playlist</returns>
        public static Playlist PlaylistFromFolder(string url, string name = "default")
        {
            Playlist playlist = new Playlist(name);
            playlist.PopulateFromFolder(url);
            return playlist;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Name and Songs contained</returns>
        public override string ToString()
        {
            return "Playlist: " + Name + "  Songs: " + base.ToString();
        }

        /// <summary>
        /// Fill a playlist with songs from a folder.
        /// </summary>
        /// <param name="url">The url of the folder.</param>
        public void PopulateFromFolder(string url)
        {
            string[] files = Directory.GetFiles(url);
            foreach (string file in files)
            {
                Add(new Local(file));
            }
        }
    }
}
