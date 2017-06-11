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

namespace Edu_Piano_9012.UI.Sub
{
    /// <summary>
    /// Position.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Position : Page
    {

        public Position()
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
            var expand2 = new DoubleAnimation(250,
                         250, TimeSpan.FromMilliseconds(500));
            TestStack.Children[1].BeginAnimation(StackPanel.HeightProperty, expand1);
            TestStack.Children[0].BeginAnimation(StackPanel.HeightProperty, expand2);
            TestStack.Children[2].BeginAnimation(StackPanel.HeightProperty, expand2);
            //if (form.ShowDialog() == true)
            //{
            //    device = form.SelectedDevice;
            //}

            //StopListenning();
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
        static string[] NotePath = { "\\도.png", "\\레.png", "\\미.png", "\\파.png", "\\솔.png", "\\라.png", "\\시.png" };
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
            if (frequency > 0 && frequency < 1211)
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
                else if (noteName.Equals("미") && (int)Note.미 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("파") && (int)Note.파 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("솔") && (int)Note.솔 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("라") && (int)Note.라 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
                else if (noteName.Equals("시") && (int)Note.시 == stackInfo[1]) { TestStack.Children.RemoveAt(0); set = true; }
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
