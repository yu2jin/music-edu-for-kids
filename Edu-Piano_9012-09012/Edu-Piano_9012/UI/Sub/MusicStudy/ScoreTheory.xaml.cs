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
	public partial class ScoreTheory
	{
        private Window1 window;
        int count = -1;
        Image[] images = new Image[7];
		public ScoreTheory(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
			// 개체 만들기에 필요한 코드를 이 지점 아래에 삽입하십시오.
            count = -1;
            btn_goMain.Click += btn_goMain_Click;
            btn_back.Click += btn_back_Click;
            btn_after.Click += btn_after_Click;
            btn_before.Click += btn_before_Click;

            Load();

        }
        string[] NotePath = { @"\02. 교육자료_음쉼표.png", @"\03. 교육자료_자리표.png", @"\04. 교육자료_높은음자리 음계.png", @"\05. 교육자료_낮은음자리 음계.png"
                                , @"\06. 교육자료_악보기본.png", @"\07. 교육자료_온음반음.png", @"\08. 교육자료_셈여림표.png" };
        void Load()
        {
            for (int i = 0; i < 7; i++)
            {
                Image img_C = new Image();
                BitmapImage bi3 = new BitmapImage();


                bi3.BeginInit();
                bi3.UriSource = new Uri(@"\교육자료" + NotePath[i], UriKind.Relative);
                bi3.EndInit();
                img_C.Width = 1200;
                img_C.Height = 700;
                img_C.Stretch = Stretch.Fill;
                img_C.Source = bi3;
                images[i] = img_C;
            }
        }

        void btn_before_Click(object sender, RoutedEventArgs e)
        {
            if (count > 0)
            {
                count--;
                ScoreStack.Children.Clear();
                ScoreStack.Children.Add(images[count]);
                
            }
        }

        void btn_after_Click(object sender, RoutedEventArgs e)
        {
            if (count < 6)
            {
                count++;
                ScoreStack.Children.Clear();
                ScoreStack.Children.Add(images[count]);
                
            }
               
        }

        void btn_back_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new MusicStudyPage1(window));
        }

        void btn_goMain_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Main(window));
        }
	}
}