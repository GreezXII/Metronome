using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Metronome
{
    class AudioEngine
    {
        private readonly WaveOut outputDevice;
        private readonly MixingSampleProvider mixer;

        private AudioFileReader accentedBeat;
        private AudioFileReader normalBeat;

        public AudioEngine(int sampleRate = 44100, int channelCount = 1)
        {
            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
            accentedBeat = new AudioFileReader("Sounds/snare.wav");
            normalBeat = new AudioFileReader("Sounds/hi-hat.wav");
        }

        public void Start()
        {
            while (true)
            {
                mixer.AddMixerInput(accentedBeat.ToWaveProvider());
                Thread.Sleep(1000);
                mixer.AddMixerInput(normalBeat.ToWaveProvider());
                Thread.Sleep(1000);
                mixer.AddMixerInput(normalBeat.ToWaveProvider());
                Thread.Sleep(1000);
                mixer.AddMixerInput(normalBeat.ToWaveProvider());
                Thread.Sleep(1000);
            }
        }
    }
}
