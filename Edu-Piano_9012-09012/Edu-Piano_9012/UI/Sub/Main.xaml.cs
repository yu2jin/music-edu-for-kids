using Edu_Piano_9012.UI.Sub.Quiz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Edu_Piano_9012.UI.Sub
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {
        private Window1 window;
        public Main(Window1 window)
        {
            InitializeComponent();
            this.window = window;
            btn_end.Click += btn_end_Click;
            btn_insPlay.Click += btn_insPlay_Click;
            btn_study.Click += btn_study_Click;
            btn_quiz.Click += btn_quiz_Click;
            btn_insSound.Click += btn_insSound_Click;
        }

        void btn_insSound_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new InsSoundPage1(window));
        }

        void btn_quiz_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new quizPage1(window));
        }

        void btn_study_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new MusicStudyPage1(window));
        }

        void btn_insPlay_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new InsPlayPage1(window));
        }

        void btn_end_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            Process.GetCurrentProcess().Kill();
        }
    }
}
