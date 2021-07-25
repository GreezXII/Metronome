﻿using System;
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
        private AudioEngine audioEngine;

        public MainWindow()
        {
            InitializeComponent();
            audioEngine = new AudioEngine();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            audioEngine.Play();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            audioEngine.Stop();
        }
    }
}
