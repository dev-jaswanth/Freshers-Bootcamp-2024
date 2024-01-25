using System;
using Zeiss.DoorSystemLib;

namespace DoorSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleDoor basicDoor = new SimpleDoor();
            DoorController basicDoorController = new DoorController(basicDoor);

            SmartDoor advancedDoor = new SmartDoor();
            DoorController advancedDoorController = new DoorController(advancedDoor);

            AlertBuzzer buzzer = new AlertBuzzer();
            AlertPager pager = new AlertPager();
            AutoShutManager autoShut = new AutoShutManager(advancedDoor);

            Action buzzerSignal = new Action(buzzer.RaiseAlert);
            Action pagerSignal = new Action(pager.RaiseAlert);
            Action autoShutSignal = new Action(autoShut.RaiseAlert);

            advancedDoor.AlertTriggered += buzzerSignal + pagerSignal + autoShutSignal;

            advancedDoor.AlertThreshold = 5;
            advancedDoor.Activate();
            Console.ReadLine();

            advancedDoor.AlertTriggered -= buzzerSignal;
            advancedDoor.AlertTriggered -= autoShutSignal;
        }
    }
}
