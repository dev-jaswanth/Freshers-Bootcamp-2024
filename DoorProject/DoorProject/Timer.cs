using System;
using System.Threading;

namespace DoorProject
{
    public class Timer
    {
        private System.Threading.Timer _timer;
        public event Action Elapsed;

        public Timer()
        {
            _timer = new System.Threading.Timer(callback => OnElapsed(), null, Timeout.Infinite, Timeout.Infinite);
        }

        public void SetTimer(int seconds)
        {
            _timer.Change(seconds * 1000, Timeout.Infinite);
        }

        protected void OnElapsed()
        {
            Elapsed?.Invoke();
        }
    }
}
