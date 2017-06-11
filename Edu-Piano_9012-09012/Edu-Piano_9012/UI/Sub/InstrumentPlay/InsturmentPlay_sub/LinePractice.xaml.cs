using Edu_Piano_9012.Engine;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Edu_Piano_9012.UI.Sub.InstrumentPlay.InsturmentPlay_sub
{
    /// <summary>
    /// LinePractice.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LinePractice : Page
    {
        String currentPath;
        DirectoryInfo di;
        song Song;
        int AllNote;
        public LinePractice(int selectedIndex, song Song)
        {
            InitializeComponent();

            this.Song = Song;
            Thread t = new Thread(StopListenning);
            SoundCapture.SoundCaptureDevice device = null;
            SelectDeviceForm form = new SelectDeviceForm();
            device = form.SelectedDevice;
            this.selectedIndex = selectedIndex;
            Clear();
            t.Start();
            bool finished = t.Join(TimeSpan.FromMilliseconds(300));
            if (!finished)
                t.Abort();

            if (device != null)
            {
                StartListenning(device);
            }
            Song.btn_LinePractice.Focus();
        }
        double closestFrequency = 0.0;
        string noteName = null;
        string[] NotePath;

        string[] syllableNames = { "솔.미.미.파.레.레.도.레.미.파.솔.솔.솔..솔.미.미.미.파.레.레.도.미.솔.솔.미.미.미..레.레.레.레.레.미.파.미.미.미.미.미.파.솔..솔.미.미.파.레.레.도.미.솔.미.레.미.도"
                                 , "도.미.솔.도.미.솔.라.라.라.솔..파.파.파.미.미.미.레.레.레.도"
                                 , "솔.솔.미.미.레.도.도.도.라.라.솔.솔.미.레.레.미..도.라.솔.라.솔.미.미.레.라.솔.미.솔.미.레.솔.도"
                                 , "솔.솔.라.라.솔.솔.미.솔.솔.미.미.레..솔.솔.라.라.솔.솔.미.솔.미.레.미.도"
                                 };
        string[] s;
        int count = 0;
        public enum Note { 도, 레, 미, 파, 솔, 라, 시 };
        int selectedIndex = 0;


        private void StopListenning()
        {
            if (song.frequencyInfoSource != null)
            {
                song.frequencyInfoSource.Stop();
                song.frequencyInfoSource.FrequencyDetected -= new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected);
                song.frequencyInfoSource = null;

            }
        }

        private void StartListenning(SoundCapture.SoundCaptureDevice device)
        {

            song.frequencyInfoSource = new SoundFrequencyInfoSource(device);
            song.frequencyInfoSource.FrequencyDetected += new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected);
            song.frequencyInfoSource.Listen();
        }

        void frequencyInfoSource_FrequencyDetected(object sender, FrequencyDetectedEventArgs e)
        {
            if (!Dispatcher.CheckAccess()) // CheckAccess returns true if you're on the dispatcher thread
            {
                Dispatcher.Invoke(new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected), sender, e);

            }
            else
            {

                UpdateFrequecyDisplays(e.Frequency);
            }
        }

        public void Clear()
        {
            

            TestStack.Children.Clear();

            if (selectedIndex == 0)
            {
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                currentPath = Environment.CurrentDirectory;
                currentPath = currentPath.Replace(@"\", @"\\");
                currentPath = currentPath + @"\\동요연습\\나비야";
                AllNote = 57;
                NotePath = new string[58];
                di = new DirectoryInfo(currentPath);
                int i = 0;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    NotePath[i] = f.Name;
                    i++;
                }
                currentPath = currentPath + @"\\";
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[0], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                s = syllableNames[0].Split(new char[] { '.' });
            }
            else if (selectedIndex == 1)
            {
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                currentPath = Environment.CurrentDirectory;
                currentPath = currentPath.Replace(@"\", @"\\");
                currentPath = currentPath + @"\\동요연습\\똑같아요";
                AllNote = 21;
                NotePath = new string[22];
                di = new DirectoryInfo(currentPath);
                int i = 0;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    NotePath[i] = f.Name;
                    i++;
                }
                currentPath = currentPath + @"\\";
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[0], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                s = syllableNames[1].Split(new char[] { '.' });
            }
            else if (selectedIndex == 2)
            {
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                currentPath = Environment.CurrentDirectory;
                currentPath = currentPath.Replace(@"\", @"\\");
                currentPath = currentPath + @"\\동요연습\\짝짜꿍";
                AllNote = 33;
                NotePath = new string[34];
                di = new DirectoryInfo(currentPath);
                int i = 0;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    NotePath[i] = f.Name;
                    i++;
                }
                currentPath = currentPath + @"\\";
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[0], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                s = syllableNames[2].Split(new char[] { '.' });
            }
            else if (selectedIndex == 3)
            {
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                currentPath = Environment.CurrentDirectory;
                currentPath = currentPath.Replace(@"\", @"\\");
                currentPath = currentPath + @"\\동요연습\\학교종";
                AllNote = 25;
                NotePath = new string[26];
                di = new DirectoryInfo(currentPath);
                int i = 0;
                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    NotePath[i] = f.Name;
                    i++;
                }
                currentPath = currentPath + @"\\";
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[0], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                s = syllableNames[3].Split(new char[] { '.' });
            }

            count = 0;
        }

        bool setSecond = true;
        private void UpdateFrequecyDisplays(double frequency)
        {
            if (setSecond == false)
            {
                setSecond = true;
                Thread.Sleep(500);
            }
            if ((count == 13 || count == 28 || count == 43) && selectedIndex == 0)
            {
                TestStack.Children.RemoveAt(0);
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                Random ranNote = new Random();
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[count + 1], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                count++;
                setSecond = false;
            }
            else if (count == 10 && selectedIndex == 1)
            {
                TestStack.Children.RemoveAt(0);
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                Random ranNote = new Random();
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[count + 1], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                count++;
                setSecond = false;
            }
            else if (count == 16 && selectedIndex == 2)
            {
                TestStack.Children.RemoveAt(0);
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                Random ranNote = new Random();
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[count + 1], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                count++;
                setSecond = false;
            }
            else if (count == 12 && selectedIndex == 3)
            {
                TestStack.Children.RemoveAt(0);
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();
                Random ranNote = new Random();
                bi3.BeginInit();
                bi3.UriSource = new Uri(currentPath + NotePath[count + 1], UriKind.Absolute);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);
                count++;
                setSecond = false;
            }

            if (frequency > 127 && frequency < 1211 && setSecond == true)
            {
                #region 주파수 분석
                if (frequency > 129 && frequency < 133) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 137 && frequency < 141) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 145 && frequency < 149) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 153 && frequency < 157) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 161 && frequency < 165) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 172 && frequency < 176) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 182 && frequency < 186) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 194 && frequency < 198) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 207 && frequency < 212) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 218 && frequency < 222) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 231 && frequency < 235) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 245 && frequency < 250) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 258 && frequency < 262) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 275 && frequency < 279) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 290 && frequency < 294) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 308 && frequency < 312) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 327 && frequency < 331) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 345 && frequency < 349) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 365 && frequency < 369) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 388 && frequency < 392) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 410 && frequency < 414) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 434 && frequency < 438) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 467 && frequency < 471) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 493 && frequency < 497) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 523 && frequency < 527) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 556 && frequency < 560) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 586 && frequency < 590) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 619 && frequency < 623) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 656 && frequency < 660) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 698 && frequency < 702) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 745 && frequency < 749) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 787 && frequency < 791) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 830 && frequency < 834) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 880 && frequency < 884) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 936 && frequency < 940) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 978 && frequency < 982) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 1048 && frequency < 1052) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 1100 && frequency < 1104) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 1189 && frequency < 1193) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else { return; }
                #endregion
                //closeFrequencyTextBox.Text = closestFrequency.ToString(); 
                //noteNameTextBox.Text = noteName;
                BitmapImage bmpImg = new BitmapImage();
                bmpImg.BeginInit();
                if (noteName.Equals("도"))
                {
                    bmpImg.UriSource = new Uri("\\piano01.png", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }
                else if (noteName.Equals("레"))
                {
                    bmpImg.UriSource = new Uri("\\piano02.png", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }
                else if (noteName.Equals("미"))
                {
                    bmpImg.UriSource = new Uri("\\piano03.png", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }
                else if (noteName.Equals("파"))
                {
                    bmpImg.UriSource = new Uri("\\piano04.png", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }
                else if (noteName.Equals("솔"))
                {
                    bmpImg.UriSource = new Uri("\\piano05.jpg", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }
                else if (noteName.Equals("라"))
                {
                    bmpImg.UriSource = new Uri("\\piano06.png", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }
                else if (noteName.Equals("시"))
                {
                    bmpImg.UriSource = new Uri("\\piano07.png", UriKind.Relative);
                    bmpImg.EndInit();
                    Image_Piano.Source = bmpImg;
                }



                #region 자리연습
                bool set = false;
                if (noteName.Equals("도") && s[count].Equals("도")) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("레") && s[count].Equals("레")) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("미") && s[count].Equals("미")) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("파") && s[count].Equals("파")) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("솔") && s[count].Equals("솔")) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("라") && s[count].Equals("라")) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("시") && s[count].Equals("시")) { TestStack.Children.RemoveAt(0); set = true; }
                if (set == true)
                {
                    Image img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    Random ranNote = new Random();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(currentPath + NotePath[count + 1], UriKind.Absolute);
                    bi3.EndInit();
                    img_C.Width = 1200;
                    img_C.Height = 350;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    TestStack.Children.Add(img_C);
                    count++;
                }
                if (count == AllNote)
                {
                    Clear();
                }
                #endregion
            }
        }

        static string[] NoteNames = { "라", "라#", "시", "도", "도#", "레", "레#", "미", "파", "파#", "솔", "솔#" };

        static double ToneStep = Math.Pow(2, 1.0 / 12);

        private void FindClosestNote(double frequency, out double closestFrequency, out string noteName)
        {
            const double AFrequency = 440.0;
            const int ToneIndexOffsetToPositives = 120;
            int toneIndex = (int)Math.Round(Math.Log(frequency / AFrequency, ToneStep));
            noteName = NoteNames[(ToneIndexOffsetToPositives + toneIndex) % NoteNames.Length];
            closestFrequency = Math.Pow(ToneStep, toneIndex) * AFrequency;
        }
    }
}
