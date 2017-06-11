using Edu_Piano_9012.UI.Sub;
using Edu_Piano_9012.UI.Sub.MusicStudy.MusicStudy_sub;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
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
	public partial class MusicTale
	{
        private Window1 window;
        public static WaveOut waveOut;
		public MusicTale(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
            btn_back.Click += btn_back_Click;
            btn_goMain.Click += btn_goMain_Click;

            String currentPath = Environment.CurrentDirectory;

            currentPath = currentPath.Replace(@"\", @"\\");
            //MessageBox.Show(currentPath);
            DirectoryInfo di = new DirectoryInfo(currentPath + "\\음악이야기");
            int i = 0;
            foreach (System.IO.DirectoryInfo d in di.GetDirectories())
            {
                lb_musicTale.Items.Add(new MusicTale_Control(d.Name, i));
                i++;
            }

            lb_musicTale.SelectionChanged += lb_musicTale_SelectionChanged;
        }

        void lb_musicTale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = lb_musicTale.SelectedItem as MusicTale_Control;
            if (item != null)
            {
                TaleFrame.Navigate(new MusicTale_Sub(item.number));
            }
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
            window.MainFrame.Navigate(new MusicStudyPage1(window));
        }
	}
}