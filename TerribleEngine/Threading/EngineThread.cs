using System;
using System.Threading;
using TerribleEngine.Timing;

namespace TerribleEngine.Threading
{
    public class EngineThread
    {
        public ThrottledTimer Timer { get; }
        public Thread Thread { get; }
        public int UpdateRate { get; } = 60;

        private Action OnInit;
        private Action OnNewFrame;


        private bool exit;

        public EngineThread(Action init, Action onNewFrame, int rate)
        {
            UpdateRate = rate;
            OnInit = init;
            OnNewFrame = onNewFrame;
            Thread = new Thread(RunWork);
            Timer = new ThrottledTimer(true, UpdateRate);
        }

        private void RunWork()
        {
            OnInit?.Invoke();
            while (!exit)
            {
                ProcessFrame();
            }
        }

        public void ProcessFrame()
        {
            OnNewFrame?.Invoke();
            Timer.Tick();
        }

        public void Start()
        {
            Thread.Start();
        }

        public void Exit()
        {
            exit = true;
        }
    }
}