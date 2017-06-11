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
using SoundCapture;
using Edu_Piano_9012.Engine;
using Edu_Piano_9012.UI.Sub;
using System.Diagnostics;

namespace Edu_Piano_9012
{
   
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
            MainFrame.Navigate(new Main(this));
            this.MouseDown += Window1_MouseDown;  
        }
        void Window1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
