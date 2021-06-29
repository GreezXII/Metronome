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

        public SampleSource accentedBeat;
        private SampleSource normalBeat;

        public AudioEngine(int sampleRate = 44100, int channelCount = 2)
        {
            accentedBeat = new SampleSource(accentedBeatPath);
            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            outputDevice.Init(mixer);
            outputDevice.Play();
        }
    }
}
