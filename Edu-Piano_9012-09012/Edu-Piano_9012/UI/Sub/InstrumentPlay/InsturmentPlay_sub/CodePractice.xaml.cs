using Edu_Piano_9012.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edu_Piano_9012.UI.Sub.InstrumentPlay.InsturmentPlay_sub
{
    /// <summary>
    /// CodePractice.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CodePractice : Page
    {
        public CodePractice()
        {
            InitializeComponent();
            Thread t = new Thread(StopListenning);
            SoundCapture.SoundCaptureDevice device = null;
            SelectDeviceForm form = new SelectDeviceForm();
            Random ranNote = new Random();
            Image img_C = new Image();
            BitmapImage bi3 = new BitmapImage();



            bi3.BeginInit();
            bi3.UriSource = new Uri("\\처음.png", UriKind.Relative);
            bi3.EndInit();
            img_C.Width = 400;
            img_C.Height = 350;
            img_C.Stretch = Stretch.Fill;
            img_C.Source = bi3;
            TestStack.Children.Add(img_C);
            for (int i = 1; i < 3; i++)
            {
                img_C = new Image();
                bi3 = new BitmapImage();
                int val = ranNote.Next(0, 7);
                stackInfo[i] = val;

                bi3.BeginInit();
                bi3.UriSource = new Uri(NotePath[val], UriKind.Relative);
                bi3.EndInit();
                img_C.Width = 400;
                img_C.Height = 350;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                TestStack.Children.Add(img_C);

            }

            var expand1 = new DoubleAnimation(TestStack.ActualHeight,
                                 350, TimeSpan.FromMilliseconds(500));
            var expand2 = new DoubleAnimation(250, 250, TimeSpan.FromMilliseconds(500));
            TestStack.Children[1].BeginAnimation(StackPanel.HeightProperty, expand1);
            TestStack.Children[0].BeginAnimation(StackPanel.HeightProperty, expand2);
            TestStack.Children[2].BeginAnimation(StackPanel.HeightProperty, expand2);
            //if (form.ShowDialog() == true)
            //{
            //    device = form.SelectedDevice;
            //}
            t.Start();
            bool finished = t.Join(TimeSpan.FromMilliseconds(300));
            if (!finished)
                t.Abort();



            device = form.SelectedDevice;
            if (device != null)
            {
                StartListenning(device);
            }
        }
        double closestFrequency = 0.0;
        string noteName = null;
        static string[] NotePath = { "\\기타코드\\도.png", "\\기타코드\\레.png", "\\기타코드\\미.png", "\\기타코드\\파.png", "\\기타코드\\솔.png", "\\기타코드\\라.png", "\\기타코드\\시.png" };
        int[] stackInfo = new int[3];
        public enum Note { 도, 레, 미, 파, 솔, 라, 시 };



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

        private void UpdateFrequecyDisplays(double frequency)
        {
            if (frequency > 127 && frequency < 1211)
            {
                #region 주파수 분석
                if (frequency > 128 && frequency < 132) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 137 && frequency < 141) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 145 && frequency < 149) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 154 && frequency < 158) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 163 && frequency < 167) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 173 && frequency < 177) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 183 && frequency < 187) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 194 && frequency < 198) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 206 && frequency < 210) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 218 && frequency < 222) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 231 && frequency < 235) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 245 && frequency < 250) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 259 && frequency < 265) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 275 && frequency < 279) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 292 && frequency < 296) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 309 && frequency < 313) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 328 && frequency < 332) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 347 && frequency < 351) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 368 && frequency < 372) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 390 && frequency < 394) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 413 && frequency < 417) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 438 && frequency < 442) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 464 && frequency < 470) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 492 && frequency < 496) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 521 && frequency < 525) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 554 && frequency < 558) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 585 && frequency < 589) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 620 && frequency < 624) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 657 && frequency < 661) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 696 && frequency < 700) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 738 && frequency < 742) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 782 && frequency < 786) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 829 && frequency < 833) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 878 && frequency < 882) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 932 && frequency < 936) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 986 && frequency < 990) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 1045 && frequency < 1049) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 1107 && frequency < 1111) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else if (frequency > 1173 && frequency < 1177) { FindClosestNote(frequency, out closestFrequency, out noteName); }
                else { return; }
                #endregion
                FindClosestNote(frequency, out closestFrequency, out noteName);
                Debug.WriteLine(frequency + " " + closestFrequency.ToString() + " " + noteName);
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
                if (noteName.Equals("도") && (int)Note.도 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("레") && (int)Note.레 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if ((noteName.Equals("미") || noteName.Equals("솔#")) && (int)Note.미 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("파") && (int)Note.파 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("솔") && (int)Note.솔 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if ((noteName.Equals("도#") || noteName.Equals("라")) && (int)Note.라 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if ((noteName.Equals("시") || noteName.Equals("레#") || noteName.Equals("파#") ) && (int)Note.시 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                if (set == true)
                {
                    Image img_C = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    Random ranNote = new Random();
                    int val = ranNote.Next(0, 7);
                    for (int i = 0; i < 2; i++)
                    {
                        stackInfo[i] = stackInfo[i + 1];
                    }
                    stackInfo[2] = val;
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(NotePath[val], UriKind.Relative);
                    bi3.EndInit();
                    img_C.Width = 400;
                    img_C.Height = 350;
                    img_C.Stretch = Stretch.Fill;
                    img_C.Source = bi3;
                    TestStack.Children.Add(img_C);
                    var expand1 = new DoubleAnimation(0,
                                 350, TimeSpan.FromMilliseconds(250));
                    var expand2 = new DoubleAnimation(250,
                         250, TimeSpan.FromMilliseconds(500));
                    TestStack.Children[1].BeginAnimation(StackPanel.HeightProperty, expand1);
                    TestStack.Children[0].BeginAnimation(StackPanel.HeightProperty, expand2);
                    TestStack.Children[2].BeginAnimation(StackPanel.HeightProperty, expand2);
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
