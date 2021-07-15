using System;
using NAudio.Wave;

namespace Metronome
{
    class SampleSourceProvider : ISampleProvider
    {
        private readonly SampleSource sampleSource;
        private long position;

        public SampleSourceProvider(SampleSource samples)
        {
            this.sampleSource = samples;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var availableSamples = sampleSource.AudioData.Length - position;
            var samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(sampleSource.AudioData, position, buffer, offset, samplesToCopy);
            position += samplesToCopy;
            return (int)samplesToCopy;
        }

        public WaveFormat WaveFormat { get { return sampleSource.WaveFormat; } }
    }
}
