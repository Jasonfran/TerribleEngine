using System;
using System.Threading;

namespace TerribleEngine.Timing
{
    public class ThrottledTimer : BasicTimer
    {
        public double SleptTime { get; private set; }
        public double Framerate { get; private set; }
        private double accumulatedSleepError;

        private int updateRate = 60;

        public ThrottledTimer(bool start, int rate) : base(start)
        {
            updateRate = rate;
        }

        public override void Tick()
        {
            base.Tick();
            Throttle();
        }

        private void Throttle()
        {
            double targetMilliseconds = 1000.0 / updateRate;

            if (updateRate > 0)
            {
                if (ElapsedFrameTime < targetMilliseconds)
                {
                    double excessFrameTime = targetMilliseconds - ElapsedFrameTime;

                    int timeToSleepFloored = (int) Math.Floor(excessFrameTime);

                    accumulatedSleepError += excessFrameTime - timeToSleepFloored;
                    int accumulatedSleepErrorCompensation = (int) Math.Round(accumulatedSleepError);

                    // Can't sleep a negative amount of time
                    accumulatedSleepErrorCompensation =
                        Math.Max(accumulatedSleepErrorCompensation, -timeToSleepFloored);

                    accumulatedSleepError -= accumulatedSleepErrorCompensation;
                    timeToSleepFloored += accumulatedSleepErrorCompensation;

                    // We don't want re-schedules with Thread.Sleep(0). We already have that case down below.
                    if (timeToSleepFloored > 0)
                    {
                        Thread.Sleep(timeToSleepFloored);
                    }

                    // Sleep is not guaranteed to be an exact time. It only guaranteed to sleep AT LEAST the specified time. We also used some time to compute the above things, so this is also factored in here.
                    double afterSleepTime = SourceTime;
                    SleptTime = afterSleepTime - CurrentTime;
                    accumulatedSleepError += timeToSleepFloored - (afterSleepTime - CurrentTime);
                    CurrentTime = afterSleepTime;
                }
                else
                {
                    // We use the negative spareTime to compensate for framerate jitter slightly.
                    double spareTime = ElapsedFrameTime - targetMilliseconds;
                    SleptTime = 0;
                    accumulatedSleepError = -spareTime;
                }
            }

            Framerate = 1000.0f / ElapsedFrameTime;
        }
    }
}