using System;

namespace DoorProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a door type:");
            Console.WriteLine("1. Simple Door");
            Console.WriteLine("2. Smart Door");
            Console.Write("Enter your choice (1 or 2): ");
            int doorType = Convert.ToInt32(Console.ReadLine());

            if (doorType == 1)
            {
                SimpleDoor simpleDoor = new SimpleDoor();
                ControlSimpleDoor(simpleDoor);
            }
            else if (doorType == 2)
            {
                Buzzer buzzer = new Buzzer();
                Timer timer = new Timer();
                IPagerNotification pagerNotifier = new PagerNotification();
                AutoClose autoCloser = new AutoClose();

                SmartDoor smartDoor = new SmartDoor(buzzer, timer, pagerNotifier, autoCloser);
                ControlSmartDoor(smartDoor);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void ControlSimpleDoor(SimpleDoor door)
        {
            Console.WriteLine("Simple Door - Choose an action: Open (O) / Close (C)");
            char action = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (action)
            {
                case 'O':
                    door.Open();
                    Console.WriteLine("Door Opened.");
                    break;
                case 'C':
                    door.Close();
                    Console.WriteLine("Door Closed.");
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }

        static void ControlSmartDoor(SmartDoor door)
        {
            Console.WriteLine("Smart Door - Choose an action:");
            Console.WriteLine("1. Open Door");
            Console.WriteLine("2. Close Door");
            Console.Write("Enter your choice: ");
            int action = Convert.ToInt32(Console.ReadLine());

            if (action == 1)
            {
                door.OpenDoor();
                Console.WriteLine("Smart Door Opened. Timer started for 10 seconds.");
                door.DoorTimer.Elapsed += () => OnTimerElapsed(door);
            }
            else if (action == 2)
            {
                door.Close();
                Console.WriteLine("Smart Door Closed.");
            }
            else
            {
                Console.WriteLine("Invalid action.");
            }
        }

        static void OnTimerElapsed(SmartDoor door)
        {
            Console.WriteLine("The timer has elapsed. Performing actions...");
            // The actions after the timer elapses are handled within the SmartDoor class
            // Optionally, you can directly call AutoClose here if that is preferable
        }
    }
}