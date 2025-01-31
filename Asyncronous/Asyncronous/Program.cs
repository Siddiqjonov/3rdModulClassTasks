using System.Diagnostics;

namespace Asyncronous
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //Task task = Task.Run();

            //  await GetTea();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Main is started");
            //await Do1();
            //await Do2();
            //await Do3();

            //Do1();
            //Do2();
            //Do3();

            var do1Task = Do1();
            var do2Task = Do2();
            var do3Task = Do3();

            //Task.WaitAll(new Task[] { do1Task, do1Task, do3Task });
            //Task.WaitAll(do1Task, do1Task, do3Task);

            var allTask = Task.WhenAll(do1Task, do2Task, do3Task);

            Console.WriteLine("Salom donyo!");

            await allTask;

            //await do1Task;
            //await do2Task;
            //await do3Task;


            Console.WriteLine("Main is finished");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ToString());
        }
        public static async Task Do1()
        {
            Console.WriteLine("Do1 is started");
            await Task.Delay(6000);
            Console.WriteLine("Do1 is finished");
        }
        public static async Task Do2()
        {
            Console.WriteLine("Do2 is started");
            await Task.Delay(5000);
            Console.WriteLine("Do2 is finished");
        }
        public static async Task Do3()
        {
            Console.WriteLine("Do3 is started");
            await Task.Delay(4000);
            Console.WriteLine("Do3 is finished");
        }

        public static async Task<string> GetTea()
        {
            var boiledWaterTask = await BoilWater();
            Console.WriteLine("Shkafdan choynni oldik");
            Console.WriteLine("Coynakga quruq choy soldik");

            //await boiledWaterTask;

            var res = $"Choynakga {boiledWaterTask} quydik";

            Console.WriteLine(res);
            return res;
        }
        public static async Task<string> BoilWater()
        {
            Console.WriteLine("Tifalni yoqdik");

            // Thread.Sleep(5000);

            await Task.Delay(5000);

            Console.WriteLine("Suv qaynadi");
            return "qaynagan suv";
        }
    }
}
