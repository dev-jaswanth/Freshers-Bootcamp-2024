using System;

namespace DoorProject
{
    public class AutoClose
    {
        public void Execute(SmartDoor door)
        {
            door.Close();
            Console.WriteLine("AutoClose: Door is now closed.");
        }
    }
}
