namespace PlayerLibrary.Structures.Songs
{
    /// <summary>
    /// The abstract superclass that defines the base format for all song types.
    /// </summary>
    public abstract class Song
    {
        /// <summary>
        /// The song's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The song's artist.
        /// </summary>
        public string Artist { get; set; }
        
        /// <summary>
        /// The album the song belongs to.
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Where the track appears in the album.
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// Which disc the track is on in the album.
        /// </summary>
        public int DiscNumber { get; set; }

        /// <summary>
        /// The song's genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// The location the song is stored at.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Loads the song.
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Plays the song.
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// Pauses the song.
        /// </summary>
        public abstract void Pause();

        /// <summary>
        /// Stops the song and unloads it.
        /// </summary>
        public abstract void Stop();
    }
}
