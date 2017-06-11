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
	public partial class StringInstrument
	{
        private Window1 window;
        WaveOut waveOut;
        String currentPath;
   

		public StringInstrument(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;

            currentPath = Environment.CurrentDirectory;
            currentPath = currentPath.Replace(@"\", @"\\");
            currentPath = currentPath + "\\악기소리\\";

            btn_azaeng.Click += btn_azaeng_Click;
            btn_back.Click += btn_back_Click;
            btn_chel.Click += btn_chel_Click;
            btn_gaya.Click += btn_gaya_Click;
            btn_goMain.Click += btn_goMain_Click;
            btn_guitar.Click += btn_guitar_Click;
            btn_hae.Click += btn_hae_Click;
            btn_har.Click += btn_har_Click;
            btn_ucu.Click += btn_ucu_Click;
            btn_violin.Click += btn_violin_Click;
            btn_vipa.Click += btn_vipa_Click;
        }

        void btn_vipa_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "비파.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_violin_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "바이올린.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_ucu_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "우쿨렐레.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_har_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "하프.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_hae_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "해금.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }



        void btn_guitar_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "기타.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        

        void btn_gaya_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "가야금.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }


        void btn_chel_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "첼로.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

       

        void btn_azaeng_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "아쟁.wav");
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