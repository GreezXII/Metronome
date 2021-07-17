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

        public Pattern(int bpm = 200, int measure = 4)
        {
            BPM = bpm;
            BeatDuration = 60.0 / BPM / 4;
            Measure = 10;
        }

        public SampleSource CreatePattern(SampleSource sample)
        {
            long step = (long)(sample.WaveFormat.SampleRate * sample.WaveFormat.Channels * (sample.WaveFormat.BitsPerSample / 8) * BeatDuration);
            long length =  step * Measure;
            
            float[] buffer = new float[length];

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
