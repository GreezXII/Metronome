using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        private void SelectFileDialog(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 или WAV|*.mp3;*.wav";
            if (openFileDialog.ShowDialog() == true)
            {
                Button s = sender as Button;
                switch (s.Name)
                {
                    case "btnSelectAccentedBeatFile":
                        txtAccentedBeatFilePath.Text = openFileDialog.FileName;
                        break;
                    case "btnSelectNormalBeatFile":
                        txtNormalBeatFilePath.Text = openFileDialog.FileName;
                        break;
                }
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void btnApplySettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AudioEngine.ApplyBeatSound(txtAccentedBeatFilePath.Text, txtNormalBeatFilePath.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Невозможно изменить звук метронома. Проверьте путь к аудио-файлам.\n\nПодробности:\n{exc.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
