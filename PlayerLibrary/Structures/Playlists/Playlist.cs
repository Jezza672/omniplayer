using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLibrary.Structures.Songs;
using System.Drawing;
using System.IO;
using System.Collections;

namespace PlayerLibrary.Structures.Playlists
{
    public class Playlist : List<Song>
    {
        /// <summary>
        /// The playlist's name.
        /// </summary>
        public String Name { get; set; }


        public float Duration {
            get
            {
                return this.Sum(i => i.Duration);
            }
        }

        /// <summary>
        /// The thumbnail image of the playlist.
        /// </summary>
        //public Bitmap Thumbnail { get; set; }


        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="name">The name of the playlist</param>
        public Playlist(String name = "default")
        {
            Name = name;
        }


        /// <summary>
        /// ToString method, returns name and songs.
        /// </summary>
        /// <returns></returns>
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
                base.Add(new Local(file));
            }
        }

        /// <summary>
        /// Create a new playlist filled with songs from a folder.
        /// </summary>
        /// <param name="url">The url of the folder.</param>
        /// <param name="name">The name of the playlist being created.</param>
        /// <returns></returns>
        public static Playlist PlaylistFromFolder(string url, string name = "default")
        {
            Playlist playlist = new Playlist(name);
            playlist.PopulateFromFolder(url);
            return playlist;
        }
    }
}
