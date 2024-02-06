using System;

namespace DoorSystemLib
{
    public class SmartDoor : SimpleDoor
    {
        public int AlertThreshold { get; set; }
        public event Action AlertTriggered;
        private CountdownManager countdownTimer;

        public override void Activate()
        {
            base.Activate();
            InitializeTimer(AlertThreshold);
        }
        public override void Deactivate()
        {
            base.Deactivate();
        }
        private void InformObservers()
        {
            if (AlertTriggered != null)
            {
                AlertTriggered.Invoke();
            }
        }
        public void InitializeTimer(int duration)
        {
            Console.WriteLine($"Setting timer for {duration} seconds\n");

            countdownTimer = new CountdownManager(duration);
            countdownTimer.BeginCountdown((remainingSeconds) =>
            {
                if (remainingSeconds == 0)
                {
                    InformObservers();
                }
            });
        }
    }
}
