using System.Diagnostics;

namespace TerribleEngine.Timing
{
    public class BasicTimer : IClock
    {
        private Stopwatch sourceStopwatch;

        protected double SourceTime => (double)sourceStopwatch.ElapsedTicks / Stopwatch.Frequency * 1000;

        public double CurrentTime { get; set; }

        public double LastFrameTime { get; set; }

        public double ElapsedFrameTime => CurrentTime - LastFrameTime;

        public BasicTimer(bool start)
        {
            sourceStopwatch = new Stopwatch();

            if (start)
            {
                sourceStopwatch.Start();
            }
        }

        public virtual void Tick()
        {
            LastFrameTime = CurrentTime;
            CurrentTime = SourceTime;
        }
    }
}