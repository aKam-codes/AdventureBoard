using AdventureBoard.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Windows;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace AdventureBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel.ViewModel SBViewModel { get; set; }


        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSound();
            SBViewModel = new ViewModel.ViewModel();
        }

        private void InitializeSound()
        {
            this.Closed += new EventHandler(AppExit_Event);
        }

        private void soundBtn_Clicked(object sender, RoutedEventArgs E)
        {
            //SBViewModel.PlaySound_Command.FireCanExecuteChanged();
            Debug.WriteLine("\n - Sound Btn Clicked -");

        }

        private void AppExit_Event(object sender, EventArgs e)
        {
            Debug.WriteLine("\n - Exit Cleanup Hit -");
            SBViewModel.cleanUpFiles();
        }

        
    }
}
