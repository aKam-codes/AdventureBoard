using SoundBoard_v2.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Windows;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace SoundBoard_v2
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

            // TODO figure out what happened with event handler
            SBViewModel.getSoundModel(0).PlaySound_Command.FireCanExecuteChanged();
            //SBViewModel.getSoundModel(0).playSound();

        }

        private void AppExit_Event(object sender, EventArgs e)
        {
            Debug.WriteLine("\n - Exit Cleanup Hit -");
            SBViewModel.cleanUpFiles();
        }

        
    }
}
