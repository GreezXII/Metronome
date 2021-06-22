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

        private string accentedBeatPath = "Sounds/snare.wav";
        private string normalBeatPath = "Sounds/hi-hat.wav";

        private CachedSound accentedBeat;
        private CachedSound normalBeat;

        private DispatcherTimer timer;
        private int beatCount = 1;

        public AudioEngine(int sampleRate = 44100, int channelCount = 2)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(PlayBeat);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 800);

            CreateAudioCache();
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
            CachedSoundSampleProvider provider = new CachedSoundSampleProvider(accentedBeat);
            mixer.AddMixerInput(provider);
        }

        private void PlayNormalBeat()
        {
            CachedSoundSampleProvider provider = new CachedSoundSampleProvider(normalBeat);
            mixer.AddMixerInput(provider);
        }

        private void CreateAudioCache()
        {
            this.accentedBeat = new CachedSound(this.accentedBeatPath);
            this.normalBeat = new CachedSound(this.normalBeatPath);
        }
    }
}
