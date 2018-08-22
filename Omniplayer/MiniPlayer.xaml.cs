using System;
using System.Collections.Generic;
using System.Globalization;
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
using PlayerLibrary.Structures.Songs;
using System.Windows.Threading;

namespace Omniplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player Player = new Player();
        private bool muted = false;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            PlaylistViewer.ItemsSource = Player.Queue;
            Player.RaisePlayEvent += Song_Change;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start(); 
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Transport.Value = Player.Position;
            LeftTimeCode.Text = doubleToHMS(Player.Position);
            RightTimeCode.Text = doubleToHMS(Player.Position - Player.Duration);
        }

        void Song_Change(object sender, PlayEventArgs e)
        {
            Transport.Maximum = e.Duration;
            NowplayingText.Text = "Now Playing: " + e.Song.ToString();
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
        
        private void PlaylistViewer_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString("00");
        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {

        }

        private string doubleToHMS(double time)
        {
            bool negative = false;
            if (time < 0)
            {
                negative = true;
                time = -time;
            }
            int hours = (int)(time / 3600);
            int minutes = (int)(time / 60) % 60;
            int seconds = (int)time % 60;
            return (negative ? "-" : "") + hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }

        private void PlaylistViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Console.WriteLine(row.DataContext);
            Player.PlaySong((Song)row.DataContext);

            var image = (Image)PlayPauseButton.Content;
            image.Source = new BitmapImage(new Uri("Resources/Icons/Controls/pause.png", UriKind.Relative));
        }

        private void PlayListAddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class DurationSecondsToFormattedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            TimeSpan t = TimeSpan.FromSeconds((double)value);
            return t.ToString(@"mm\:ss");
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return 12.0;
        }
    }
}
