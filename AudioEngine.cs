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
        public static string AccentedBeatPath { get; set; } = "Sounds/snare.wav"; // TODO: объединить в класс Beat путь к файлу, семпл, громкость и т.д.
        public static string NormalBeatPath { get; set; } = "Sounds/hi-hat.wav";
        private static PatternEngine patternEngine = new PatternEngine();
        private static SampleSource AccentedPattern { get; set; }
        private static SampleSource NormalPattern { get; set; }
        public static VolumeSampleProvider accentedVolumeProvider { get; set; }
        public static VolumeSampleProvider normalVolumeProvider { get; set; }
        // Metronome settings
        private static bool isPlaying = false;
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
            AccentedPattern = patternEngine.CreateAccentedBeatPattern(BPM, Measure);
            NormalPattern = patternEngine.CreateNormalBeatPattern(BPM, Measure);

            // Create Volume Providers
            accentedVolumeProvider = new VolumeSampleProvider(new SampleSourceProvider(AccentedPattern));
            normalVolumeProvider = new VolumeSampleProvider(new SampleSourceProvider(NormalPattern));

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
                accentedVolumeProvider = new VolumeSampleProvider(new SampleSourceProvider(AccentedPattern));
                normalVolumeProvider = new VolumeSampleProvider(new SampleSourceProvider(NormalPattern));
                accentedVolumeProvider.Volume = 1.0f;
                normalVolumeProvider.Volume = 1.0f;
                mixer.AddMixerInput(accentedVolumeProvider);
                mixer.AddMixerInput(normalVolumeProvider);
                outputDevice.Play();
                isPlaying = true;
            }
        }

        public static void Stop()
        {
            if (isPlaying)
            {
                mixer.RemoveAllMixerInputs();
                outputDevice.Stop();
                isPlaying = false;
            }
        }

        public static void Update()
        {
            if (isPlaying)
            {
                Stop();
                AccentedPattern = patternEngine.CreateAccentedBeatPattern(BPM, Measure);
                NormalPattern = patternEngine.CreateNormalBeatPattern(BPM, Measure);
                Play();
            }
            else
            {
                AccentedPattern = patternEngine.CreateAccentedBeatPattern(BPM, Measure);
                NormalPattern = patternEngine.CreateNormalBeatPattern(BPM, Measure);
            }
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
