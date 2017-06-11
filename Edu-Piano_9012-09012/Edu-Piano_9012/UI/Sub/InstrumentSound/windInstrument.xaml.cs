using Edu_Piano_9012.UI.Sub;
using NAudio.Wave;
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
using System.Windows.Shapes;

namespace Edu_Piano_9012
{
	public partial class windInstrument
	{
        private Window1 window;
        WaveOut waveOut;
        String currentPath;
		public windInstrument(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
			// 개체 만들기에 필요한 코드를 이 지점 아래에 삽입하십시오.
            currentPath = Environment.CurrentDirectory;
            currentPath = currentPath.Replace(@"\", @"\\");
            currentPath = currentPath + "\\악기소리\\";

            btn_back.Click += btn_back_Click;
            btn_goMain.Click += btn_goMain_Click;
            btn_basson.Click += btn_basson_Click;
            btn_flute.Click += btn_flute_Click;
            btn_horn.Click += btn_horn_Click;
            btn_recorder.Click += btn_recorder_Click;
            btn_saxophone.Click += btn_saxophone_Click;
            btn_trombone.Click += btn_trombone_Click;
            btn_trumpet.Click += btn_trumpet_Click;
            btn_clarinet.Click += btn_clarinet_Click;


		}

        void btn_clarinet_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath+"클라리넷.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_trumpet_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "트럼펫.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_trombone_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "트럼본.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_saxophone_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "색소폰.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_recorder_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "리코더.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_horn_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "호른.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_flute_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "플루트.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_basson_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "바순.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_goMain_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }
            window.MainFrame.Navigate(new Main(window));
        }

        void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }
            window.MainFrame.Navigate(new InsSoundPage1(window));
        }
	}
}