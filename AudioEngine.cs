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

        public AudioEngine(int sampleRate = 44100, int channelCount = 2)
        {
            patternEngine.AccentedBeat = new SampleSource(accentedBeatPath);
            patternEngine.NormalBeat = new SampleSource(normalBeatPath);
            Pattern = patternEngine.CreatePattern(120, 4);

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
            outputDevice.Stop();
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
