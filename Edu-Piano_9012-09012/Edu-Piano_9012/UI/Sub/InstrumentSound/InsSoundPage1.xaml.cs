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
	public partial class InsSoundPage1
	{
        private Window1 window;
		public InsSoundPage1(Window1 window)
		{
			this.InitializeComponent();
            this.window = window;
            btn_windInstrument.Click += btn_windInstrument_Click;
            btn_stringInstrument.Click += btn_stringInstrument_Click;
            btn_percussion.Click += btn_percussion_Click;
            btn_back.Click += btn_back_Click;
		}

        void btn_back_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Main(window));
        }

        void btn_percussion_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Percussion(window));
        }

        void btn_stringInstrument_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new StringInstrument(window));
        }

        void btn_windInstrument_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new windInstrument(window));
        }
	}

}