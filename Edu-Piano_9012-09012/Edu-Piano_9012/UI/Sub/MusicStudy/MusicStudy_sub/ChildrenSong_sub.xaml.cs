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
    /// ChildrenSong_sub.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChildrenSong_sub : UserControl
    {
        public String filePath;
        public ChildrenSong_sub(String name, String path)
        {
            InitializeComponent();
            tb_songName.Text = name;
            filePath = path;
        }
    }
}
