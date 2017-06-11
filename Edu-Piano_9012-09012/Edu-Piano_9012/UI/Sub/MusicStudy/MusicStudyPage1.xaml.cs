using Edu_Piano_9012.UI.Sub;
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
	public partial class MusicStudyPage1
	{
        private Window1 window;
		public MusicStudyPage1(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
			// 개체 만들기에 필요한 코드를 이 지점 아래에 삽입하십시오.
            btn_back.Click += btn_back_Click;
            btn_musicTale.Click += btn_musicTale_Click;
            btn_childrenSong.Click += btn_childrenSong_Click;
            btn_scoreTheory.Click += btn_scoreTheory_Click;
		}

        void btn_scoreTheory_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new ScoreTheory(window));
        }

        void btn_childrenSong_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new ChildrenSong(window));
        }

        void btn_musicTale_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new MusicTale(window));
        }

        void btn_back_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Main(window));
        }
	}
}