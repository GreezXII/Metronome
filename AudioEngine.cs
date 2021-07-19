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

        public SampleSource accentedBeat;
        private SampleSource normalBeat;

        public AudioEngine(int sampleRate = 44100, int channelCount = 2)
        {
            accentedBeat = new SampleSource(accentedBeatPath);
            normalBeat = new SampleSource(normalBeatPath);
            PatternEngine patternEngine = new PatternEngine();
            SampleSource pattern = patternEngine.CreatePattern(accentedBeat, normalBeat);

            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.AddMixerInput(new SampleSourceProvider(pattern));

            outputDevice.Init(mixer);
            outputDevice.Play();
        }
    }
}
