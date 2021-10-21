using System;
using NAudio.Wave;


namespace Metronome
{
    class PatternEngine
    {
        private int BPM { get; set; }
        private int Measure { get; set; }
        private double BeatDuration { get; set; }
        public SampleSource AccentedBeat { get; set; }
        public SampleSource NormalBeat { get; set; }

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

        public SampleSource CreatePattern(int bpm, int measure)  // Remove?
        {
            Initialize(bpm, measure);
            long beatLength = GetBeatLength(AccentedBeat.WaveFormat);
            long fullLength = beatLength * Measure;

            float[] buffer = new float[fullLength];

            long index = 0;
            SampleSource beat;
            while (index < buffer.Length)
            {
                //  Copy accented beat first
                if (index == 0)
                    beat = AccentedBeat;
                else
                    beat = NormalBeat;

                if (beat.Length > beatLength)
                    Array.Copy(beat.AudioData, 0, buffer, index, beatLength);
                else
                    Array.Copy(beat.AudioData, 0, buffer, index, beat.AudioData.Length);

                index += beatLength;
            }

            return new SampleSource(buffer, AccentedBeat.WaveFormat);
        }

        public SampleSource CreateAccentedBeatPattern(int bpm, int measure)
        {
            Initialize(bpm, measure);
            long beatLength = GetBeatLength(AccentedBeat.WaveFormat);
            long fullLength = beatLength * Measure;

            float[] buffer = new float[fullLength];
            if (AccentedBeat.Length > beatLength)
                Array.Copy(AccentedBeat.AudioData, 0, buffer, 0, beatLength);
            else
                Array.Copy(AccentedBeat.AudioData, 0, buffer, 0, AccentedBeat.AudioData.Length);

            return new SampleSource(buffer, AccentedBeat.WaveFormat);
        }

        public SampleSource CreateNormalBeatPattern(int bpm, int measure)
        {
            Initialize(bpm, measure);
            long beatLength = GetBeatLength(NormalBeat.WaveFormat);
            long fullLength = beatLength * Measure;

            float[] buffer = new float[fullLength];

            long index = beatLength;
            while (index < buffer.Length)
            {
                if (NormalBeat.Length > beatLength)
                    Array.Copy(NormalBeat.AudioData, 0, buffer, index, beatLength);
                else
                    Array.Copy(NormalBeat.AudioData, 0, buffer, index, NormalBeat.AudioData.Length);

                index += beatLength;
            }

            return new SampleSource(buffer, AccentedBeat.WaveFormat);
        }
    }
}
