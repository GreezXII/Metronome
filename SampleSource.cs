using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;


namespace Metronome
{
    class SampleSource
    {
        public float[] AudioData { get; private set; }       // Audio samples
        public WaveFormat WaveFormat { get; private set; }   // Information about format of sample rate, channes, etc
        public long Length { get; private set; }             // Length of stream in bytes
        public double Duration { get; private set; }         // Length of stream in seconds

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

        public SampleSource(float[] audioData, WaveFormat waveFormat)
        {
            WaveFormat = waveFormat;
            Length = audioData.Length;
            Duration = (double)Length / (WaveFormat.SampleRate * WaveFormat.Channels * (WaveFormat.BitsPerSample / 8));
            AudioData = AudioData;
        }

        // TODO: Проверить, чтобы файл не был длиннее endTime
        public void IncreaseDuration(double endTime)
        {
            double additionalDuration = Math.Abs(Duration - endTime);
            long additionalLength = (long)(WaveFormat.SampleRate * WaveFormat.Channels * WaveFormat.BitsPerSample / 8 * additionalDuration);
            float[] buffer = new float[Length + additionalLength];
            AudioData.CopyTo(buffer, 0);
            AudioData = buffer;
            Length = Length + additionalLength;
            Duration = Duration + additionalDuration;
        }

        public static SampleSource operator + (SampleSource A, SampleSource B)
        {
            float[] buffer = new float[A.Length + B.Length];
            A.AudioData.CopyTo(buffer, 0);
            B.AudioData.CopyTo(buffer, A.Length);
            return new SampleSource(buffer, A.WaveFormat);
        }

        public static SampleSource operator * (SampleSource sample, int factor)
        {
            float[] buffer = new float[sample.Length * factor];
            long index = 0;
            for (int i = 0; i < factor; i++)
            {
                sample.AudioData.CopyTo(buffer, index);
                index += sample.Length;
            }
            return new SampleSource(buffer, sample.WaveFormat);
        }

        public static SampleSource operator * (int factor, SampleSource sample)
        {
            float[] buffer = new float[sample.Length * factor];
            long index = 0;
            for (int i = 0; i < factor; i++)
            {
                sample.AudioData.CopyTo(buffer, index);
                index += sample.Length;
            }
            return new SampleSource(buffer, sample.WaveFormat);
        }
    }
}
