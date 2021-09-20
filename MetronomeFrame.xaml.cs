using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for MetronomeFrame.xaml
    /// </summary>
    public partial class MetronomeFrame : Page
    {
        public MetronomeFrame()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBPM();
            AudioEngine.Play();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            AudioEngine.Stop();
        }

        private void bpmTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int caretIndex = bpmTextBox.CaretIndex;  // Save caret position to restore it after text update
            string input = "";
            // Check input when user try to paste  
            foreach (char c in bpmTextBox.Text.TrimStart('0'))  // Trim start zeros
                if (char.IsDigit(c))
                    input += c;
                else
                    caretIndex -= 1;  // Prevent index changing when character is not allowed
            bpmTextBox.Text = input;
            bpmTextBox.CaretIndex = caretIndex;
        }

        private void bpmTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle if Key is digit or backspace
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Back))
                e.Handled = true;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBPM();
        }

        private void UpdateBPM()
        {
            AudioEngine.BPM = int.Parse(bpmTextBox.Text);
            AudioEngine.Measure = int.Parse(measureComboBox.Text);
            AudioEngine.Update();
            bpmLabel.Content = AudioEngine.BPM.ToString() + "/" + AudioEngine.Measure.ToString();
        }

    }
}
