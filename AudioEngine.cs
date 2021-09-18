using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Metronome
{
    class AudioEngine
    {
        private readonly WaveOut outputDevice;
        private readonly MixingSampleProvider mixer;

        private string accentedBeatPath = "Sounds/snare.wav";
        private string normalBeatPath = "Sounds/hi-hat.wav";

        PatternEngine patternEngine = new PatternEngine();
        SampleSource Pattern { get; set; }

        public int MinBPM { get; set; } = 20;
        public int MaxBPM { get; set; } = 500;

        public AudioEngine(int bpm = 120, int measure = 4, int sampleRate = 44100, int channelCount = 2)
        {
            patternEngine.AccentedBeat = new SampleSource(accentedBeatPath);
            patternEngine.NormalBeat = new SampleSource(normalBeatPath);
            Pattern = patternEngine.CreatePattern(bpm, measure);

            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));

            outputDevice.Init(mixer);
        }

        public void Play()
        {
            mixer.AddMixerInput(new SampleSourceProvider(Pattern));
            outputDevice.Play();
        }

        public void Stop()
        {
            mixer.RemoveAllMixerInputs();
        }

        public void Update(int bpm, int measure)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Stop();
                Pattern = patternEngine.CreatePattern(bpm, measure);
                Play();
            }
            else
                Pattern = patternEngine.CreatePattern(bpm, measure);
        }
    }
}
