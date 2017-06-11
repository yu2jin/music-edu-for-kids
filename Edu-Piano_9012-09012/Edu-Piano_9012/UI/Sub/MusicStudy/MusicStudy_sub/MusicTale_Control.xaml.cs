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

namespace Edu_Piano_9012.UI.Sub.MusicStudy.MusicStudy_sub
{
    /// <summary>
    /// MusicTale_Control.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MusicTale_Control : UserControl
    {
        public int number;
        public MusicTale_Control(String Name, int number)
        {
            InitializeComponent();
            label_Name.Content = Name;
            this.number = number;
        }
    }
}
