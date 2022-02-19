using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Streams.Effects;
using CSCore.DSP;

namespace Reverb
{
    public partial class MainWindow : Form
    {
        private readonly WasapiCapture soundIn;
        private readonly WasapiOut soundOut;
        private readonly DmoWavesReverbEffect reverbBass, reverbMiddle, reverbTreble;
        public MainWindow()
        {
            InitializeComponent();
            soundIn = new WasapiCapture(true, AudioClientShareMode.Shared, 0);
            soundIn.Initialize();
            var source1 = new SoundInSource(soundIn) { FillWithZeros = true };
            var source2 = new SoundInSource(soundIn) { FillWithZeros = true };
            var source3 = new SoundInSource(soundIn) { FillWithZeros = true };

            //Apply bandpass filter to each frequency group
            var bassFilter = source1.ToSampleSource().AppendSource(x => new BiQuadFilterSource(x));
            bassFilter.Filter = new HighpassFilter(bassFilter.WaveFormat.SampleRate, 100);
            var bassSource = bassFilter.AppendSource(x => new BiQuadFilterSource(x));
            bassSource.Filter = new LowpassFilter(bassSource.WaveFormat.SampleRate, 1200);

            var middleFilter = source2.ToSampleSource().AppendSource(x => new BiQuadFilterSource(x));
            middleFilter.Filter = new HighpassFilter(middleFilter.WaveFormat.SampleRate, 1200);
            var middleSource = middleFilter.AppendSource(x => new BiQuadFilterSource(x));
            middleSource.Filter = new LowpassFilter(middleSource.WaveFormat.SampleRate, 2300);

            var trebleFilter = source3.ToSampleSource().AppendSource(x => new BiQuadFilterSource(x));
            trebleFilter.Filter = new HighpassFilter(trebleFilter.WaveFormat.SampleRate, 2300);
            var trebleSource = trebleFilter.AppendSource(x => new BiQuadFilterSource(x));
            trebleSource.Filter = new LowpassFilter(trebleSource.WaveFormat.SampleRate, 3400);

            //Apply reverb effect
            reverbMiddle = new DmoWavesReverbEffect(middleSource.ToWaveSource());
            reverbBass = new DmoWavesReverbEffect(bassSource.ToWaveSource());
            reverbTreble = new DmoWavesReverbEffect(trebleSource.ToWaveSource());

            //Initialize mixer
            var mixer = new SimpleMixer(2, 44100)
            {
                FillWithZeros = true,
                DivideResult = true
            };
            mixer.AddSource(reverbBass.ToSampleSource().ChangeSampleRate(44100).ToStereo());
            mixer.AddSource(reverbMiddle.ToSampleSource().ChangeSampleRate(44100).ToStereo());
            mixer.AddSource(reverbTreble.ToSampleSource().ChangeSampleRate(44100).ToStereo());

            //Initialize the soundout with the mixer 
            soundOut = new WasapiOut() { Latency = 1 };
            soundOut.Initialize(mixer.ToWaveSource());
        }

        private void Bass_Scroll(object sender, EventArgs e)
        {
            reverbBass.ReverbTime = Bass.Value;
        }

        private void Middle_Scroll(object sender, EventArgs e)
        {
            reverbMiddle.ReverbTime = Middle.Value;
        }

        private void Treble_Scroll(object sender, EventArgs e)
        {
            reverbTreble.ReverbTime = Treble.Value;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            soundOut.Dispose();
            soundIn.Dispose();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            soundIn.Start();
            soundOut.Play();
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            soundIn.Stop();
            soundOut.Stop();
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
        }
    }
}
