using System;
using System.Threading;

namespace DoorSystemLib
{
    public class CountdownManager
    {
        public int Duration { get; private set; }

        public CountdownManager(int timerLimit)
        {
            Duration = timerLimit;
        }
        public void BeginCountdown(Action<int> onComplete)
        {
            for (int i = Duration; i >= 0; i--)
            {
                Console.WriteLine($"Countdown: {i} seconds left");
                Thread.Sleep(1000);
            }
            onComplete?.Invoke(0);
        }
    }
}
