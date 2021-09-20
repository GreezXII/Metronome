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
        MetronomeFrame metronomeFrame = new MetronomeFrame();
        SettingsFrame settingsFrame = null;
        public MainWindow()
        {
            InitializeComponent();
            Frame.Content = metronomeFrame;
        }

        private void MetronomeViewButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = metronomeFrame;
        }

        private void SettingsViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (settingsFrame == null)
                Frame.Content = new SettingsFrame();
            else
                Frame.Content = settingsFrame;
        }
    }
}
