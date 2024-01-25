using System;

namespace DoorProject
{
    public class SmartDoor : SimpleDoor
    {
        public Buzzer DoorBuzzer { get; private set; }
        public Timer DoorTimer { get; private set; }
        public IPagerNotification PagerNotifier { get; private set; }
        public AutoClose DoorAutoCloser { get; private set; }

        public SmartDoor(Buzzer buzzer, Timer timer, IPagerNotification pagerNotifier, AutoClose autoCloser)
        {
            DoorBuzzer = buzzer;
            DoorTimer = timer;
            PagerNotifier = pagerNotifier;
            DoorAutoCloser = autoCloser;

            DoorTimer.Elapsed += OnTimerElapsed;
        }

        public void OpenDoor()
        {
            Open();
            DoorTimer.SetTimer(1); // Start timer for 10 seconds
        }

        private void OnTimerElapsed()
        {
            DoorBuzzer.MakeNoise();
            PagerNotifier.SendNotification("The door has been open for 10 seconds.");
            DoorAutoCloser.Execute(this);
        }
    }
}
