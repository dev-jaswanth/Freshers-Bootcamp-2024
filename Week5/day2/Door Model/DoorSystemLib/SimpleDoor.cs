using System;

namespace DoorSystemLib
{
    public class SimpleDoor
    {
        public DoorState CurrentState { get; set; }
        public virtual void Activate()
        {
            if (this.CurrentState == DoorState.Closed)
            {
                this.CurrentState = DoorState.Opened;
                Console.WriteLine("Door state changed: Open\n");
            }
        }
        public virtual void Deactivate()
        {
            if (this.CurrentState == DoorState.Opened)
            {
                this.CurrentState = DoorState.Closed;
                Console.WriteLine("Door state changed: Closed\n");
            }
        }
    }

    public enum DoorState
    {
        Closed,
        Opened
    }
}
