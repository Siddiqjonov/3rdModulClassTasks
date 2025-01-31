using System.Diagnostics;

namespace TwoThreadUsingOneMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread thread1 = new Thread(IncrementNumber);
            Thread thread2 = new Thread(IncrementNumber);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Counter: {_counter}");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ToString());
        }

        public static int _counter = 0;

        public static Object _lock = new Object();

        public static void IncrementNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                lock(_lock)
                {
                    ++_counter;
                    Console.WriteLine($"Counter: {_counter}");
                    Console.WriteLine($"ThredId: {Thread.CurrentThread.ManagedThreadId}");
                    Console.WriteLine($"ThredId: {Thread.CurrentThread.ThreadState}");
                }
                Thread.Sleep(100);
            }
        }
    }
}
