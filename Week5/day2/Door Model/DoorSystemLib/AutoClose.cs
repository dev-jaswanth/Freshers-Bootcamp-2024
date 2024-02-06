using System;

namespace DoorSystemLib
{
    public class AutoShutManager
    {
        public SmartDoor controlledSmartDoor;
        public AutoShutManager(SmartDoor door)
        {
            controlledSmartDoor = door;
        }
        public void RaiseAlert()
        {
            Console.WriteLine("Auto shutdown initiated.");
            controlledSmartDoor.Deactivate();
        }
    }
}
