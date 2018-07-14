using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlayerLibrary.Player;

namespace Omniplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player Player = new Player();
        private bool muted = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            Player.Prev();
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            var image = (Image)PlayPauseButton.Content;
            if (!Player.Playing)
            {              
                Player.Play();
                image.Source = new BitmapImage(new Uri("Resources/Icons/Controls/pause.png", UriKind.Relative));
            }
            else
            {
                Player.Pause();
                image.Source = new BitmapImage(new Uri("Resources/Icons/Controls/play.png", UriKind.Relative));
            }
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Player.Next();
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!muted)
            {
                int vol = (int)(Volume.Value * Volume.Value * (100.0 / 121.0));
                if (vol < 1 && Volume.Value != 0)
                    vol = 1;
                Player.Volume = vol;
            }
        }

        private void VolumeText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (muted)
            {
                Binding b = new Binding();
                b.Path = new PropertyPath("Value");
                b.ElementName = "Volume";
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.StringFormat = "00";
                VolumeText.SetBinding(TextBlock.TextProperty, b);
                muted = false;
                Volume_ValueChanged(sender, new RoutedPropertyChangedEventArgs<double>(12, 13));
            }
            else
            {
                VolumeText.Text = "🔇";
                muted = true;
                Player.Volume = 0;
            }
        }
    }
}
