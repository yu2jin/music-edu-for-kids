using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edu_Piano_9012.UI.Sub.InstrumentPlay.InsturmentPlay_sub
{
    /// <summary>
    /// SelectSong.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SelectSong : Page
    {
        song Song;
        int select = 0;
        public SelectSong(song Song, int select)
        {
            InitializeComponent();
            this.Song = Song;
            btn_butterfly.Click += btn_butterfly_Click;
            btn_clap.Click += btn_clap_Click;
            btn_equal.Click += btn_equal_Click;
            btn_schoolBell.Click += btn_schoolBell_Click;
            this.select = select;
        }

        void btn_schoolBell_Click(object sender, RoutedEventArgs e)
        {
            if (select == 0)
            {
                Song.songFrame.Navigate(new LinePractice(3, Song));
            }
            else if (select == 1)
            {
                Song.songFrame.Navigate(new SongPractice(3, Song));
            }
        }

        void btn_equal_Click(object sender, RoutedEventArgs e)
        {
            if (select == 0)
            {
                Song.songFrame.Navigate(new LinePractice(1, Song));
            }
            else if (select == 1)
            {
                Song.songFrame.Navigate(new SongPractice(1, Song));
            }
        }

        void btn_clap_Click(object sender, RoutedEventArgs e)
        {
            if (select == 0)
            {
                Song.songFrame.Navigate(new LinePractice(2, Song));
            }
            else if (select == 1)
            {
                Song.songFrame.Navigate(new SongPractice(2, Song));
            }
        }

        void btn_butterfly_Click(object sender, RoutedEventArgs e)
        {
            if (select == 0)
            {
                Song.songFrame.Navigate(new LinePractice(0, Song));
            }
            else if (select == 1)
            {
                Song.songFrame.Navigate(new SongPractice(0, Song));
            }
        }

 
    }
}
