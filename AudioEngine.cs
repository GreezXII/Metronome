using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Metronome
{
    static class AudioEngine
    {
        // Output device and mixer
        private static readonly WaveOut outputDevice;
        private static readonly MixingSampleProvider mixer;
        // Beat pattern
        private static string accentedBeatPath = "Sounds/snare.wav";
        private static string normalBeatPath = "Sounds/hi-hat.wav";
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
            patternEngine.AccentedBeat = new SampleSource(accentedBeatPath);
            patternEngine.NormalBeat = new SampleSource(normalBeatPath);
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
            mixer.AddMixerInput(new SampleSourceProvider(Pattern));
        }

        public static void Stop()
        {
            mixer.RemoveAllMixerInputs();
        }

        public static void Update()
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Stop();
                Pattern = patternEngine.CreatePattern(BPM, Measure);
                Play();
            }
            else
                Pattern = patternEngine.CreatePattern(BPM, Measure);
        }
    }
}
