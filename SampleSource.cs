using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;

namespace Metronome
{
    class SampleSource
    {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }
        public long Length { get; private set; }
        public double Duration { get; private set; } // in seconds

        public SampleSource(string audioFileName)
        {
            AudioFileReader reader = new AudioFileReader(audioFileName);
            using (reader)
            {
                WaveFormat = reader.WaveFormat;
                Length = reader.Length;
                Duration = (double)Length / (WaveFormat.SampleRate * WaveFormat.Channels * (WaveFormat.BitsPerSample / 8));
                AudioData = new float[Length];
                reader.Read(AudioData, 0, (int)Length);
            }
        }
    }
}
