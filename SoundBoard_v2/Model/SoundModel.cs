using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard_v2.Model
{
    public class SoundModel : INotifyPropertyChanged
    {   
        // Sound File details
        private string name { get; set; }
        private string filePath { get; set; }

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private Boolean fileExists = false;

        private Boolean isPlaying = false;

        public PlaySound_Command PlaySound_Command { get; }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor 
        public SoundModel(string nm,string fp)
        {
            this.name = nm;
            this.filePath = fp;

            fileExists = File.Exists(filePath);
            PlaySound_Command = new PlaySound_Command(this);
        }

        public void playSound()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent(); // create new SoundCard Device

                // Restart Audio when it has completed
                outputDevice.PlaybackStopped += (object o, StoppedEventArgs a) => {
                    Console.WriteLine(name + " was stopped");
                    audioFile.Position = 0;
                    isPlaying = false;
                };
            }

            if (audioFile == null)
            {
                audioFile = new AudioFileReader(filePath);
                outputDevice.Init(audioFile);
            }

            // If it's already playing, restart
            if (isPlaying)
            {
                outputDevice?.Stop();
                audioFile.Position = 0;
            }

            // Actual Play Command
            outputDevice.Play();
            isPlaying = true;
        }

        public Boolean getFileExists()
        {
            return fileExists;
        }

        public void cleanUp()
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
    }
}
