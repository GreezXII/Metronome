using System;


namespace Metronome
{
    class PatternEngine
    {
        public int BPM { get; set; }
        public int Measure { get; set; }
        private double BeatDuration { get; set; }

        public PatternEngine(int bpm = 200, int measure = 4)
        {
            BPM = bpm;
            BeatDuration = 60.0 / BPM / 4;
            Measure = measure;
        }

        public SampleSource CreatePattern(SampleSource accentedBeat, SampleSource normalBeat)
        {
            long step = (long)(accentedBeat.WaveFormat.SampleRate * accentedBeat.WaveFormat.Channels * (accentedBeat.WaveFormat.BitsPerSample / 8) * BeatDuration);
            long length = step * Measure;

            float[] buffer = new float[length];

            long index = 0;
            SampleSource beat;
            while (index < buffer.Length)
            {
                //  Copy accented beat first
                if (index == 0)
                    beat = accentedBeat;
                else
                    beat = normalBeat;

                if (beat.Length > step)
                    Array.Copy(beat.AudioData, 0, buffer, index, step);
                else
                    Array.Copy(beat.AudioData, 0, buffer, index, beat.AudioData.Length);

                index += step;
            }

            return new SampleSource(buffer, accentedBeat.WaveFormat);
        }
    }
}
