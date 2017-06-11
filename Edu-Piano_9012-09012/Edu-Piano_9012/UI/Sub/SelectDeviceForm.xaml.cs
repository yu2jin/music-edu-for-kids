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
using SoundCapture;
namespace Edu_Piano_9012.UI.Sub
{
    /// <summary>
    /// SelectDeviceForm.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SelectDeviceForm : Window
    {
        SoundCaptureDevice[] devices;

        public SoundCaptureDevice SelectedDevice
        {
            get { return devices[deviceNamesListBox.SelectedIndex]; }
        }

        public SelectDeviceForm()
        {
            InitializeComponent();
            LoadDevices();
            oKButton.Click += oKButton_Click;
        }

        void oKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (deviceNamesListBox.SelectedIndex < 0) return;


            this.Close();
        }


        private void LoadDevices()
        {
            deviceNamesListBox.Items.Clear();

            //int defaultDeviceIndex = 0;

            devices = SoundCaptureDevice.GetDevices();
            for (int i = 0; i < devices.Length; i++)
            {
                deviceNamesListBox.Items.Add(devices[i].Name + i);
                //if (devices[i].IsDefault)
                //    defaultDeviceIndex = i;
            }

            deviceNamesListBox.SelectedIndex = 1;
        }


    }
}
