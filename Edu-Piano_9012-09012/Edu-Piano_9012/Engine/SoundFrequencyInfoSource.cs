using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundCapture;
using SoundAnalysis;

namespace Edu_Piano_9012.Engine
{
    class SoundFrequencyInfoSource : FrequencyInfoSource
    {
        SoundCapture.SoundCaptureDevice device;
        Adapter adapter;

        internal SoundFrequencyInfoSource(SoundCapture.SoundCaptureDevice device)
        {
            this.device = device;
        }

        public override void Listen()
        {
            adapter = new Adapter(this, device);
            adapter.Start();
        }

        public override void Stop()
        {
            adapter.Stop();
        }

        class Adapter : SoundCapture.SoundCaptureBase
        {
            SoundFrequencyInfoSource owner;

            const double MinFreq = 60;
            const double MaxFreq = 1300;

            internal Adapter(SoundFrequencyInfoSource owner, SoundCapture.SoundCaptureDevice device)
                : base(device)
            {
                this.owner = owner;
            }

            protected override void ProcessData(short[] data)
            {
                double[] x = new double[data.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = data[i] / 32768.0;
                }

                double freq = FrequencyUtils.FindFundamentalFrequency(x, SampleRate, MinFreq, MaxFreq);
                owner.OnFrequencyDetected(new FrequencyDetectedEventArgs(freq));
            }
        }
    }
}
