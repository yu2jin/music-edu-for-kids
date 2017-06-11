using Edu_Piano_9012.Engine;
using Edu_Piano_9012.UI.Sub.InstrumentPlay.InsturmentPlay_sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edu_Piano_9012.UI.Sub.InstrumentPlay
{
    /// <summary>
    /// GuitarSong.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GuitarSong : Page
    {
        private Window1 window;
        Thread t;
        public static FrequencyInfoSource frequencyInfoSource;
        public GuitarSong(Window1 window)
        {
            InitializeComponent();
            this.window = window;
            btn_songBack.Click += btn_songBack_Click;
            btn_goMain.Click += btn_goMain_Click;
            btn_Postion.Click += btn_Postion_Click;
            btn_codePractice.Click += btn_codePractice_Click;
            t = new Thread(StopListening);
            songFrame.Navigate(new CodePractice());
        }

        void btn_codePractice_Click(object sender, RoutedEventArgs e)
        {
            songFrame.Navigate(new CodePractice());
        }




        void btn_Postion_Click(object sender, RoutedEventArgs e)
        {
            songFrame.Navigate(new Position());

        }

        void btn_goMain_Click(object sender, RoutedEventArgs e)
        {
            t.Start();
            bool finished = t.Join(TimeSpan.FromMilliseconds(300));
            if (!finished)
                t.Abort();
            window.MainFrame.Navigate(new Main(window));

        }

        void btn_songBack_Click(object sender, RoutedEventArgs e)
        {
            t.Start();
            bool finished = t.Join(TimeSpan.FromMilliseconds(300));
            if (!finished)
                t.Abort();
            window.MainFrame.Navigate(new InsPlayPage1(window));
        }
        void StopListening()
        {
            if (frequencyInfoSource != null)
            {
                frequencyInfoSource.Stop();
                frequencyInfoSource = null;
            }
        }
    }
}
