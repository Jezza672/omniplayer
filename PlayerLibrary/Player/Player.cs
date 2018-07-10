using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;
using WMPLib;

namespace PlayerLibrary.Player
{
    public class Player
    {

        private WindowsMediaPlayer WMPlayer;


        /// <summary>
        /// Constructor
        /// </summary>
        public Player()
        {
            WMPlayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            WMPlayer.MediaError += new _WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);

            string path = System.Environment.CurrentDirectory + @"/TestFiles/09 Headlights.mp3";
            Console.WriteLine(path);
            PlayFile(path);
        }

        
        /// <summary>
        /// Plays a media file given a url to the media file
        /// </summary>
        /// <param name="url"></param>
        private void PlayFile(String url)
        {
            
            WMPlayer.URL = url;
            WMPlayer.controls.play();
        }

        /// <summary>
        /// Event handler for when the state of the player changes
        /// </summary>
        /// <param name="NewState"></param>
        private void Player_PlayStateChange(int NewState)
        {
            var NewPlayState = (WMPPlayState)NewState;
            Console.WriteLine(NewPlayState.ToString());
        }

        /// <summary>
        /// Event handler for when the player encounters a media error
        /// </summary>
        /// <param name="pMediaObject"></param>
        private void Player_MediaError(object pMediaObject)
        {
            Console.WriteLine("Media either doesn't exist or cannot be played");
        }
    }
}
