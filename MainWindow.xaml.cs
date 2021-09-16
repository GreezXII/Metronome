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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AudioEngine audioEngine = new AudioEngine();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            audioEngine.Play();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            audioEngine.Stop();
        }

        private void bpmTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int caretIndex = bpmTextBox.CaretIndex;  // Save caret position to restore it after text update
            string input = "";
            // Check input when user try to paste  
            foreach (char c in bpmTextBox.Text)
                if (char.IsDigit(c))
                    input += c;
                else
                    caretIndex -= 1;  // Prevent index changing when character is not allowed
            bpmTextBox.Text = input;
            bpmTextBox.CaretIndex = caretIndex;
        }

        private void bpmTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // if Key is not digit or backspaces
            //MessageBox.Show(e.Key.ToString());
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9 && e.Key != Key.Space || e.Key == Key.Back))
                e.Handled = true;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            int bpm = 0;
            if (bpmTextBox.Text.Length != 0)
            {
                bpm = int.Parse(bpmTextBox.Text);
                if (bpm < 20)
                {
                    audioEngine.Update(20, 4);
                    bpmLabel.Content = 20;
                }
                else if (bpm > 500)
                {
                    audioEngine.Update(300, 4);
                    bpmLabel.Content = 500;
                }
                else
                {
                    audioEngine.Update(bpm, 4);
                    bpmLabel.Content = bpm;
                }
            }
            else
            {

                audioEngine.Update(bpm, 4);
            }
        }
    }
}
