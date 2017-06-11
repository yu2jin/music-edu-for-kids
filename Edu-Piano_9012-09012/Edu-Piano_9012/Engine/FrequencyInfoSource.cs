using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Edu_Piano_9012.Engine
{
    public abstract class FrequencyInfoSource
    {
        public event EventHandler<FrequencyDetectedEventArgs> FrequencyDetected;

        protected void OnFrequencyDetected(FrequencyDetectedEventArgs e)
        {
            if (FrequencyDetected != null)
            {
                FrequencyDetected(this, e);
            }
        }
        public abstract void Listen();
        public abstract void Stop();
    }

    public class FrequencyDetectedEventArgs : EventArgs
    {
        double frequency;

        public double Frequency
        {
            get { return frequency; }
        }

        public FrequencyDetectedEventArgs(double frequency)
        {
            this.frequency = frequency;
        }
    }
}
