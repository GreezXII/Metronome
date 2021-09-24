using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Metronome
{
    static class AudioEngine
    {
        // Output device and mixer
        private static readonly WaveOut outputDevice;
        private static readonly MixingSampleProvider mixer;
        private static bool isPlaying = false;
        // Beat pattern
        public static string AccentedBeatPath { get; set; } = "Sounds/snare.wav";
        public static string NormalBeatPath { get; set; } = "Sounds/hi-hat.wav";
        private static PatternEngine patternEngine = new PatternEngine();
        private static SampleSource Pattern { get; set; }
        // Metronome settings
        public static int MinBPM { get; set; } = 20;
        public static int MaxBPM { get; set; } = 500;
        private static int bpm = 120;
        public static int BPM 
        { 
            get
            {
                return bpm;
            }
            set
            {
                if (value < MinBPM)
                    bpm = MinBPM;
                else if (value > MaxBPM)
                    bpm = MaxBPM;
                else
                    bpm = value;
            }
        }
        public static int Measure { get; set; } = 4;

        static AudioEngine()
        {
            // Create beat pattern
            patternEngine.AccentedBeat = new SampleSource(AccentedBeatPath);
            patternEngine.NormalBeat = new SampleSource(NormalBeatPath);
            Pattern = patternEngine.CreatePattern(BPM, Measure);

            // Create output device and mixer
            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public static void Play()
        {
            if (!isPlaying)
            {
                mixer.AddMixerInput(new SampleSourceProvider(Pattern));
                isPlaying = true;
            }
        }

        public static void Stop()
        {
            if (isPlaying)
            {
                mixer.RemoveAllMixerInputs();
                isPlaying = false;
            }
        }

        public static void Update()
        {
            if (isPlaying)
            {
                Stop();
                Pattern = patternEngine.CreatePattern(BPM, Measure);
                Play();
            }
            else
                Pattern = patternEngine.CreatePattern(BPM, Measure);
        }

        public static void ApplyBeatSound(string accentedBeatPath, string normalBeatPath)
        {
            AccentedBeatPath = accentedBeatPath;
            NormalBeatPath = normalBeatPath;
            patternEngine.AccentedBeat = new SampleSource(AccentedBeatPath);
            patternEngine.NormalBeat = new SampleSource(NormalBeatPath);
            Update();
        }
    }
}
