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

        SampleSource pattern;

        public AudioEngine(int sampleRate = 44100, int channelCount = 2)
        {
            PatternEngine patternEngine = new PatternEngine();
            pattern = patternEngine.CreatePattern(120, 4, new SampleSource(accentedBeatPath), new SampleSource(normalBeatPath));

            outputDevice = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));

            outputDevice.Init(mixer);
        }

        public void Play()
        {
            mixer.AddMixerInput(new SampleSourceProvider(pattern));
            outputDevice.Play();
        }

        public void Stop()
        {
            outputDevice.Stop();
            mixer.RemoveAllMixerInputs();
        }
    }
}
