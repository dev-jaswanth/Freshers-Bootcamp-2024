using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    // Marker classes remain the same.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            // Start asynchronous tasks for coffee, eggs, and bacon.
            var coffeeTask = PourCoffeeAsync();
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);

            // Toast bread synchronously to avoid an unnecessary delay.
            Toast toast = ToastBread(2);

            // Await all asynchronous tasks concurrently.
            await Task.WhenAll(coffeeTask, eggsTask, baconTask);

            ApplyButter(toast);
            ApplyJam(toast);

            // Juice can be poured after other tasks complete (optional).
            Juice oj = PourOJ();

            Console.WriteLine("Breakfast is ready!");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Elapsed time: {elapsedMs} milliseconds");
        }

        private static async Task<Coffee> PourCoffeeAsync()
        {
            Console.WriteLine("Pouring coffee");
            await Task.Delay(2000); // Simulate coffee brewing time
            return new Coffee();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(1000); // Simulate egg pan warming time
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(2000); // Simulate egg cooking time
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(2000); // Simulate first side cooking time
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(2000); // Simulate second side cooking time
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait(); // Simulate toasting time
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
    }
}
