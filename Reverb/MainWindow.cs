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
        private readonly DmoWavesReverbEffect reverbBass = null, reverbMiddle = null, reverbTreble = null;
        private const int SampleRate = 44100;
        private const int GeneralBF = 65, GeneralTF = 7500;
        private const int ReverbBassBF = 65, ReverbBassTF = 300;
        private const int ReverbMiddleBF = 700, ReverbMiddleTF = 1100;
        private const int ReverbTrebleBF = 2000, ReverbTrebleTF = 3000;
        public MainWindow()
        {
            InitializeComponent();

            //Initialize WasapiCapture for recording
            soundIn = new WasapiCapture(true, AudioClientShareMode.Shared, 0);
            soundIn.Initialize();

            //Initialize the mixer
            var mixer = new SimpleMixer(2, SampleRate)
            {
                FillWithZeros = true,
                DivideResult = true
            };

            //Split the input signal into different frequency ranges, apply reverb and add to the mixer
            if (GeneralBF != ReverbBassBF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, GeneralBF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, ReverbBassBF);

                mixer.AddSource(nonEffectSource);
            }

            if (ReverbBassBF != ReverbBassTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbBassBF);
                var reverbBassSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                reverbBassSource.Filter = new LowpassFilter(SampleRate, ReverbBassTF);

                reverbBass = new DmoWavesReverbEffect(reverbBassSource.ToWaveSource());
                mixer.AddSource(reverbBass.ToSampleSource());
            }

            if (ReverbBassTF != ReverbMiddleBF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbBassTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, ReverbMiddleBF);

                mixer.AddSource(nonEffectSource);
            }

            if (ReverbMiddleBF != ReverbMiddleTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbMiddleBF);
                var reverbMiddleSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                reverbMiddleSource.Filter = new LowpassFilter(SampleRate, ReverbMiddleTF);

                reverbMiddle = new DmoWavesReverbEffect(reverbMiddleSource.ToWaveSource());
                mixer.AddSource(reverbMiddle.ToSampleSource());
            }

            if (ReverbMiddleTF != ReverbTrebleBF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbMiddleTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, ReverbTrebleBF);

                mixer.AddSource(nonEffectSource);
            }

            if (ReverbTrebleBF != ReverbTrebleTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbTrebleBF);
                var reverbTrebleSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                reverbTrebleSource.Filter = new LowpassFilter(SampleRate, ReverbTrebleTF);

                reverbTreble = new DmoWavesReverbEffect(reverbTrebleSource.ToWaveSource());
                mixer.AddSource(reverbTreble.ToSampleSource());
            }

            if (ReverbTrebleTF != GeneralTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbTrebleTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, GeneralTF);

                mixer.AddSource(nonEffectSource);
            }

            //Initialize the soundout with the mixer 
            soundOut = new WasapiOut() { Latency = 1 };
            soundOut.Initialize(mixer.ToWaveSource());
        }

        private void Bass_Scroll(object sender, EventArgs e)
        {
            if (reverbBass != null)
                reverbBass.ReverbTime = Bass.Value;
        }

        private void Middle_Scroll(object sender, EventArgs e)
        {
            if (reverbMiddle != null)
                reverbMiddle.ReverbTime = Middle.Value;
        }

        private void Treble_Scroll(object sender, EventArgs e)
        {
            if (reverbTreble != null)
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