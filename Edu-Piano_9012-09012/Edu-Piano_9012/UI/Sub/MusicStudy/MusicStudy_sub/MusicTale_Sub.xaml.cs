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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edu_Piano_9012.UI.Sub.MusicStudy.MusicStudy_sub
{
    /// <summary>
    /// MusicTale_Sub.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MusicTale_Sub : UserControl
    {
        String currentPath;
        int index;
        int locate;
        int mod;
        Image[] images = new Image[5];
        String[] audioPath = new String[5]; 
        
        public MusicTale_Sub(int index)
        {
            InitializeComponent();
            this.index = index;
            locate = 0;
            if (MusicTale.waveOut != null)
            {
                MusicTale.waveOut.Stop();
                MusicTale.waveOut = null;
            }
            TaleStack.Children.Clear();
            Load();
            btn_after.Click += btn_after_Click;
            btn_before.Click += btn_before_Click;
        }

        void btn_before_Click(object sender, RoutedEventArgs e)
        {
           

            
            if (locate > 0)
            {
                locate--;
                TaleStack.Children.Clear();
                TaleStack.Children.Add(images[locate % mod]);

                if (MusicTale.waveOut != null)
                {
                    MusicTale.waveOut.Stop();
                    MusicTale.waveOut = null;
                }

                var reader = new AudioFileReader(audioPath[locate % mod]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();

            }
            
        }

        void btn_after_Click(object sender, RoutedEventArgs e)
        {
            
            if (locate < mod - 1)
            {
                locate++;
                TaleStack.Children.Clear();
                TaleStack.Children.Add(images[locate % mod]);

                if (MusicTale.waveOut != null)
                {
                    MusicTale.waveOut.Stop();
                    MusicTale.waveOut = null;
                }

                var reader = new AudioFileReader(audioPath[locate % mod]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();

            }
        }

        private void Load()
        {
            currentPath = Environment.CurrentDirectory;
            currentPath = currentPath.Replace(@"\", @"\\");
            currentPath += @"\\음악이야기";
            if (index == 0)
            {
                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\겨울이좋아\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {
                    
                    audioPath[k] = currentPath + @"\\겨울이좋아\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\겨울이좋아\\이야기";

                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;
                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 1)
            {
                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\동물들의잔치\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\동물들의잔치\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\동물들의잔치\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;

                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 2)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\백조의호수\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\백조의호수\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\백조의호수\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;

                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 3)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\사자왕의행진\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\사자왕의행진\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\사자왕의행진\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;

                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 4)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\송어\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\송어\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\송어\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;

                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 5)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\신나는가을\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\신나는가을\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\신나는가을\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;
                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 6)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\와 봄이다\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\와 봄이다\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\와 봄이다\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;
                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 7)
            {
                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\잘자아기곰\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\잘자아기곰\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\잘자아기곰\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;
                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 8)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\폭풍치는여름\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\폭풍치는여름\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\폭풍치는여름\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;
                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
            else if (index == 9)
            {

                DirectoryInfo dir = new DirectoryInfo(currentPath + @"\\하프이야기\\이야기음악");
                int k = 0;
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {

                    audioPath[k] = currentPath + @"\\하프이야기\\이야기음악" + @"\\" + f.Name;
                    k++;
                }

                currentPath = currentPath + @"\\하프이야기\\이야기";
                DirectoryInfo di = new DirectoryInfo(currentPath);
                int i = 0;
                Image img_C = null;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + @"\\" + f.Name, UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 550;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    images[i] = img_C;
                    i++;
                }
                mod = i;
                var reader = new AudioFileReader(audioPath[0]);
                MusicTale.waveOut = new WaveOut();
                MusicTale.waveOut.Init(reader);
                MusicTale.waveOut.Play();
                TaleStack.Children.Add(images[0]);
            }
        }
    }
}
