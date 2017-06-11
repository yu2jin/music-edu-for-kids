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
	public partial class Percussion
	{
        private Window1 window;
        WaveOut waveOut;
        String currentPath;
		public Percussion(Window1 window)
		{
            this.window = window;
			this.InitializeComponent();

            currentPath = Environment.CurrentDirectory;
            currentPath = currentPath.Replace(@"\", @"\\");
            currentPath = currentPath + "\\악기소리\\";

            btn_back.Click += btn_back_Click;
            btn_goMain.Click += btn_goMain_Click;
            btn_kkang.Click += btn_kkang_Click;
            btn_silo.Click += btn_silo_Click;
            btn_simberz.Click += btn_simberz_Click;
            btn_sogo.Click += btn_sogo_Click;
            btn_tem.Click += btn_tem_Click;
            btn_tri.Click += btn_tri_Click;
            btn_zageun.Click += btn_zageun_Click;
            btn_zem.Click += btn_zem_Click;
            btn_zing.Click += btn_zing_Click;
        }

        void btn_zing_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "징.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_zem_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "젬베.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_zageun_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "작은북.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_tri_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "트라이앵글.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_tem_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "탬버린.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_sogo_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "소고.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_simberz_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "심벌즈.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_silo_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "실로폰.wav");
            waveOut = new WaveOut(); // or WaveOutEvent()

            waveOut.Init(reader);
            waveOut.Play();
        }

        void btn_kkang_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut = null;
            }

            var reader = new AudioFileReader(currentPath + "꽹과리.wav");
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