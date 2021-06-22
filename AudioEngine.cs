using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Metronome
{
    class AudioEngine
    {
        private readonly WaveOut outputDevice;
        private readonly MixingSampleProvider mixer;

        private string accentedBeat = "Sounds/snare.wav";
        private string normalBeat = "Sounds/hi-hat.wav";

        private DispatcherTimer timer;
        private int beatCount = 1;

        public AudioEngine(int sampleRate = 44100, int channelCount = 2)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(PlayBeat);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 800);

            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public void Start()
        {
            timer.Start();
        }

        private void PlayBeat(object sender, EventArgs e)
        {
            if (beatCount == 1)
            {
                PlayAccentedBeat();
                beatCount++;
            }
            else
            {
                PlayNormalBeat();
                if (beatCount == 4)
                    beatCount = 1;
                else
                    beatCount++;
            }
        }

        private void PlayAccentedBeat()
        {
            mixer.AddMixerInput(GetBeat(accentedBeat));
        }

        private void PlayNormalBeat()
        {
            mixer.AddMixerInput(GetBeat(normalBeat));
        }

        private IWaveProvider GetBeat(string path)
        {
            AudioFileReader reader = new AudioFileReader(path);
            return reader.ToWaveProvider();
        }
    }
}
