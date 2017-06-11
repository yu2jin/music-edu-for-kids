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
	public partial class ChildrenSong
	{
        private Window1 window;
        WaveOut waveOut;
        public ChildrenSong(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
            btn_back.Click += btn_back_Click;
            btn_goMain.Click += btn_goMain_Click;
            String currentPath = Environment.CurrentDirectory;

            currentPath = currentPath.Replace(@"\", @"\\");
            //MessageBox.Show(currentPath);
            DirectoryInfo di = new DirectoryInfo(currentPath + "\\동요");
            foreach (System.IO.FileInfo f in di.GetFiles())
            {
                lb_chSong.Items.Add(new ChildrenSong_sub(f.Name, currentPath + "\\동요\\" + f.Name));
            }
            lb_chSong.SelectionChanged += lb_chSong_SelectionChanged;
		    
        }

        void lb_chSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = lb_chSong.SelectedItem as ChildrenSong_sub;
            if (item != null)
            {
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut = null;
                }
                
                var reader = new AudioFileReader(item.filePath);
                waveOut = new WaveOut(); 
                waveOut.Init(reader);
                waveOut.Play();
            }
        }

        
        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
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