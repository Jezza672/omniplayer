using System.IO;

namespace PlayerLibrary.Structures.Songs
{
    /// <summary>
    /// The abstract superclass that defines the base format for all song types.
    /// </summary>
    public abstract class Song
    {
        /// <summary>
        /// Gets or sets the song's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the song's artist.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the album the song belongs to.
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Gets or sets where the track appears in the album.
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// Gets or sets which disc the track is on in the album.
        /// </summary>
        public int DiscNumber { get; set; }

        /// <summary>
        /// Gets or sets the song's genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the location the song is stored at.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the song's duration.
        /// </summary>
        public float Duration { get; set; }

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns>Returns format: "$Artist - $Title"</returns>
        public override string ToString()
        {
            return Artist + " - " + Title;
        }
    }
}
