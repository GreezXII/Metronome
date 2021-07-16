using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metronome
{
    class Pattern
    {
        public int BPM { get; set; }
        public int Measure { get; set; }
        private double BeatDuration { get; set; }

        public Pattern(int bpm = 80, int measure = 4)
        {
            BPM = bpm;
            BeatDuration = BPM / 60.0 / 4.0)
            Measure = 4;
        }

        public SampleSource CreatePattern(SampleSource sample)
        {
            //sample.IncreaseDuration(1);
            //sample = sample;
            //return sample;
            long len =  (long)(sample.WaveFormat.SampleRate * sample.WaveFormat.Channels * (sample.WaveFormat.BitsPerSample / 8) * BeatDuration);
            long step = len / Measure;
            float[] buffer = new float[len];

            long index = 0;
            while (index < buffer.Length)
            {
                if (sample.Length > step)
                    Array.Copy(sample.AudioData, 0, buffer, index, step);
                else
                    Array.Copy(sample.AudioData, 0, buffer, index, sample.AudioData.Length);

                index += step;
            }

            return new SampleSource(buffer, sample.WaveFormat);
        }
    }
}
