using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLibrary.Structures.Playlists;
using PlayerLibrary.Structures.Songs;
using WMPLib;

namespace PlayerLibrary.Player
{
    /// <summary>
    /// The Player Class.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The Windows Media Player instance.
        /// </summary>
        private WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();

        /// <summary>
        /// The Queue.
        /// </summary>
        private Playlist queue;

        /// <summary>
        /// The index of the current track being played.
        /// </summary>
        private int currentSong;

        /// <summary>
        /// Whether a song is currently being played or not.
        /// </summary>
        private bool playing;

        /// <summary>
        /// Gets whether the player is currently playing a song.
        /// </summary>
        public bool Playing
        {
            get
            {
                return playing;
            }
        }

        /// <summary>
        /// Types of loop modes.
        /// </summary>
        public enum LoopModes
        {
            /// <summary>
            /// No looping.
            /// </summary>
            None,

            /// <summary>
            /// Loop the track currently playing.
            /// </summary>
            Single,

            /// <summary>
            /// Loop the whole queue. Default
            /// </summary>
            Whole
        }

        /// <summary>
        /// Gets or sets the playback looping mode.
        /// </summary>
        public LoopModes LoopMode { get; set; }

        /// <summary>
        /// Gets or sets the current position in seconds the player is into the current media item.
        /// </summary>
        public double Position
        {
            get
            {
                return wmplayer.controls.currentPosition;
            }

            set
            {
                var temp = value;
                temp = (temp < 0) ? 0 : temp;
                temp = (temp > wmplayer.currentMedia.duration) ? wmplayer.currentMedia.duration : temp;
                wmplayer.controls.currentPosition = temp;
            }
        }

        /// <summary>
        /// Gets the duration of the current loaded media item.
        /// </summary>
        public double Duration
        {
            get
            {
                return wmplayer.currentMedia.duration;
            }
        }

        /// <summary>
        /// Gets or sets the volume of the playback, between 0 and 100.
        /// </summary>
        public int Volume
        {
            get
            {
                return wmplayer.settings.volume;
            }

            set
            {
                var temp = value;
                temp = (temp < 0) ? 0 : temp;
                temp = (temp > 100) ? 100 : temp;
                wmplayer.settings.volume = temp;
                Console.WriteLine(temp);
            }
        }

        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        public Player()
        {
            LoopMode = LoopModes.Whole;
            wmplayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            wmplayer.MediaError += new _WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            wmplayer.settings.autoStart = false;
            wmplayer.settings.volume = 30;

            queue = Playlist.PlaylistFromFolder(Environment.CurrentDirectory + @"/Testfiles/Fake Me Up", "Queue");
            Console.WriteLine(queue);

            currentSong = 0;
            wmplayer.URL = queue[currentSong].Location;
        }

        /// <summary>
        /// Resumes playback of the queue.
        /// </summary>
        public void Play()
        {
            wmplayer.controls.play();
            playing = true;
        }

        /// <summary>
        /// Pauses playback of the queue.
        /// </summary>
        public void Pause()
        {
            wmplayer.controls.pause();
            playing = false;
        }

        /// <summary>
        /// Stops playback of the queue.
        /// </summary>
        public void Stop()
        {
            wmplayer.controls.stop();
            playing = false;
        }

        /// <summary>
        /// Skips to the next song in the queue.
        /// </summary>
        public void Next()
        {
            Console.WriteLine("Current: " + playing.ToString());
            currentSong = (currentSong > queue.Count - 2) ? 0 : currentSong + 1;
            wmplayer.URL = queue[currentSong].Location;
            if (playing)
            {
                Play();
            }

            Console.WriteLine("Selecting song number {0}, {1}", currentSong, queue[currentSong].ToString());
        }

        /// <summary>
        /// Skips to the previous song in the queue.
        /// </summary>
        public void Prev()
        {
            Console.WriteLine("Current: " + playing.ToString());
            currentSong = (currentSong < 1) ? queue.Count - 1 : currentSong - 1;
            wmplayer.URL = queue[currentSong].Location;
            if (playing)
            {
                Play();
            }

            Console.WriteLine("Selecting song number {0}, {1}", currentSong, queue[currentSong].ToString());
        }

        /// <summary>
        /// Event handler for when the state of the player changes.
        /// </summary>
        /// <param name="newState">The new state, using the WMPPlayState Enum</param>
        private void Player_PlayStateChange(int newState)
        {
            var newPlayState = (WMPPlayState)newState;
            Console.WriteLine("State Change: " + newPlayState.ToString());
            if (newPlayState == WMPPlayState.wmppsMediaEnded)
            {
                switch (LoopMode)
                {
                    case LoopModes.Single:
                        Play();
                        break;
                    case LoopModes.Whole:
                        Next();
                        Play();
                        break;
                    case LoopModes.None:
                    default:
                        if (currentSong < queue.Count - 1)
                        {
                            Next();
                            Play();        
                        }
                        else
                        {
                            Stop();
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Event handler for when the player encounters a media error
        /// </summary>
        /// <param name="mediaObject"> not a clue</param>
        private void Player_MediaError(object mediaObject)
        {
            Console.WriteLine("Media either doesn't exist or cannot be played");
        }
    }
}
