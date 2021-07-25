using System;
using NAudio.Wave;


namespace Metronome
{
    class PatternEngine
    {
        private int BPM { get; set; }
        private int Measure { get; set; }
        private double BeatDuration { get; set; }

        private void Initialize(int bpm = 120, int measure = 4)
        {
            BPM = bpm;
            BeatDuration = 60.0 / BPM / 4;
            Measure = measure;
        }

        private long GetBeatLength(WaveFormat waveFormat)
        {
            return (long)(waveFormat.SampleRate * waveFormat.Channels * (waveFormat.BitsPerSample / 8) * BeatDuration);
        }

        public SampleSource CreatePattern(int bpm, int measure, SampleSource accentedBeat, SampleSource normalBeat)
        {
            Initialize(bpm, measure);
            long beatLength = GetBeatLength(accentedBeat.WaveFormat);
            long fullLength = beatLength * Measure;

            float[] buffer = new float[fullLength];

            long index = 0;
            SampleSource beat;
            while (index < buffer.Length)
            {
                //  Copy accented beat first
                if (index == 0)
                    beat = accentedBeat;
                else
                    beat = normalBeat;

                if (beat.Length > beatLength)
                    Array.Copy(beat.AudioData, 0, buffer, index, beatLength);
                else
                    Array.Copy(beat.AudioData, 0, buffer, index, beat.AudioData.Length);

                index += beatLength;
            }

            return new SampleSource(buffer, accentedBeat.WaveFormat);
        }
    }
}
