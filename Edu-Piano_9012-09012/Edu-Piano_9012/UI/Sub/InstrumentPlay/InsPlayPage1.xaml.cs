using Edu_Piano_9012.UI.Sub;
using Edu_Piano_9012.UI.Sub.InstrumentPlay;
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
	public partial class InsPlayPage1
	{
        private Window1 window;
		public InsPlayPage1(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
            btn_playPiano.Click += btn_playPiano_Click;
            btn_playGuitar.Click += btn_playGuitar_Click;
            btn_back.Click += btn_back_Click;
        }

        void btn_playGuitar_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new GuitarSong(window));
        }

        void btn_back_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Main(window));
        }

        void btn_playPiano_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new song(window));
        }
	}
}