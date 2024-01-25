using System;

namespace Zeiss.DoorSystemLib
{
    public class DoorController
    {
        public SimpleDoor controlledDoor;

        public DoorController(SimpleDoor door)
        {
            controlledDoor = door;
        }
        public void TriggerOpen()
        {
            controlledDoor.Activate();
        }
        public void TriggerClose()
        {
            controlledDoor.Deactivate();
        }
    }
}
