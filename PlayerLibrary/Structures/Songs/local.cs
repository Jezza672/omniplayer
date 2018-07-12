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
        /// Valid file extensions
        /// </summary>
        public static string[] ValidExtensions { get; set; } = { ".WAV", ".WMA", ".MP3", ".OGG" };

        /// <summary>
        /// Initializes a new instance of the Local class.
        /// </summary>
        /// <param name="url">Url to the file.</param>
        public Local(string url)
        {
            if (!IsValidFile(url))
                throw new IOException("File not supported");
            Title = url;
            Artist = "Artist";
            Album = "Album";
            TrackNumber = 0;
            DiscNumber = 0;
            Genre = "Genre";
            Duration = 1;
            Location = url;
        }

        /// <summary>
        /// Check if a file is a media file accepted by this program.
        /// </summary>
        /// <param name="path">The path of the file checked</param>
        /// <returns>Boolean if valid</returns>
        public static bool IsValidFile(string path)
        {
            ////Console.WriteLine(Path.GetExtension(path).ToUpperInvariant());
            return -1 != Array.IndexOf(ValidExtensions, Path.GetExtension(path).ToUpperInvariant());
        }
    }
}
