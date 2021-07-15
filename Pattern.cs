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

        public Pattern(int bpm = 120, int measure = 4)
        {
            BeatDuration = BPM / 60 * 4;
        }

        public SampleSource CreatePattern(SampleSource sample)
        {
            sample.IncreaseDuration(BeatDuration);
            return sample = sample * 4;
        }
    }
}
