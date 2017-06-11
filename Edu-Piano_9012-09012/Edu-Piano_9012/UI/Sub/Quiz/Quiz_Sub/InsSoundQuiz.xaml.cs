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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Edu_Piano_9012.UI.Sub.Quiz.Quiz_Sub
{
    /// <summary>
    /// InsSoundQuiz.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InsSoundQuiz : Page
    {
        private Window1 window;
        public InsSoundQuiz(Window1 window)
        {
            InitializeComponent();
            this.window = window;
            btn_back.Click += btn_back_Click;
            btn_goMain.Click += btn_goMain_Click;
        }

        void btn_goMain_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new quizPage1(window));
        }

        void btn_back_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Main(window));
        }
    }
}
