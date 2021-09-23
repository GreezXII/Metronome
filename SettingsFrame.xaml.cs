using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metronome
{
    /// <summary>
    /// Interaction logic for SettingsFrame.xaml
    /// </summary>
    public partial class SettingsFrame : Page
    {
        public SettingsFrame()
        {
            InitializeComponent();
        }

        private void btnSelectAccentedBeatFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = SelectFile();
            if (filePath != null)
                txtAccentedBeatFilePath.Text = filePath;
        }

        private void btnSelectNormalBeatFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = SelectFile();
            if (filePath != null)
                txtNormalBeatFilePath.Text = filePath;
        }

        private string SelectFile()
        {
            string filePath;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 или WAV|*.mp3;*.wav";
            if (openFileDialog.ShowDialog() == true)
                filePath = openFileDialog.FileName;
            else
                filePath = null;
            return filePath;
        }

        private void btnApplySettings_Click(object sender, RoutedEventArgs e)
        {
            AudioEngine.ApplyBeatSound(txtAccentedBeatFilePath.Text, txtNormalBeatFilePath.Text);
        }
    }
}
