using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProject
{
    public class SimpleDoor
    {
        public enum DoorState { Opened, Closed }
        public DoorState State { get; private set; }
        public string Model { get; set; }
        public string Name { get; set; }

        public void Open() { State = DoorState.Opened; }
        public void Close() { State = DoorState.Closed; }
    }

}
