using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;
using WMPLib;
using PlayerLibrary.Structures.Playlists;
using PlayerLibrary.Structures.Songs;

namespace PlayerLibrary.Player
{
    public class Player
    {

        private WindowsMediaPlayer WMPlayer;
        private Playlist Queue;
        private int CurrentSong;

        public enum PlayModes { Default, LoopSingle, LoopWhole};
        public PlayModes PlayMode { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Player()
        {
            WMPlayer = new WindowsMediaPlayer();
            PlayMode = PlayModes.Default;
            WMPlayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            WMPlayer.MediaError += new _WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            

            Queue = Playlist.PlaylistFromFolder(Environment.CurrentDirectory + @"/Testfiles/Fake Me Up", "Queue");
            Console.WriteLine(Queue);

            CurrentSong = 0;
            WMPlayer.URL = Queue[CurrentSong].Location;
            WMPlayer.controls.stop();
        }

        /// <summary>
        /// Resumes playback of the queue.
        /// </summary>
        public void Play()
        {
            WMPlayer.controls.play();
        }

        /// <summary>
        /// Pauses playback of the current queue.
        /// </summary>
        public void Pause()
        {
            WMPlayer.controls.pause();
        }

        /// <summary>
        /// Stops playback of the current queue.
        /// </summary>
        public void Stop()
        {
            WMPlayer.controls.stop();
        }

        /// <summary>
        /// Skips to the next song n the queue.
        /// </summary>
        public void Next()
        {
            CurrentSong = (CurrentSong > Queue.Count - 2) ? 0 : CurrentSong + 1;
            WMPlayer.URL = Queue[CurrentSong].Location;
            Console.WriteLine("Playing song number {0}, {1}", CurrentSong, Queue[CurrentSong].ToString());

        }

        /// <summary>
        /// Skips to the previous song in the queue.
        /// </summary>
        public void Prev()
        {
            CurrentSong = (CurrentSong < 1) ? Queue.Count - 1 : CurrentSong - 1;
            WMPlayer.URL = Queue[CurrentSong].Location;
            Console.WriteLine("Playing song number {0}, {1}", CurrentSong, Queue[CurrentSong].ToString());
        }

        /// <summary>
        /// Event handler for when the state of the player changes.
        /// </summary>
        /// <param name="NewState">The new state, using the WMPPlayState Enum</param>
        private void Player_PlayStateChange(int NewState)
        {
            var NewPlayState = (WMPPlayState)NewState;
            Console.WriteLine(NewPlayState.ToString());
            if (NewPlayState == WMPPlayState.wmppsMediaEnded)
            {
                Next();
                Play();
            }
        }

        /// <summary>
        /// Event handler for when the player encounters a media error
        /// </summary>
        /// <param name="pMediaObject"> not a clue</param>
        private void Player_MediaError(object pMediaObject)
        {
            Console.WriteLine("Media either doesn't exist or cannot be played");
        }
    }
}
