using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Metronome
{
    class PreciseTimer
    {
        int tickTime = 10; // ms
        int beatTime = 800; // ms
        public long elapsedTime;

        Stopwatch watch;

        public PreciseTimer()
        {
            watch = new Stopwatch();
            elapsedTime = Task();
        }

        private long Task()
        {
            watch.Start();
            Thread.Sleep(10);
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
    }
}
