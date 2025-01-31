namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main is started");
            Console.WriteLine($"Main threadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread thread1 = new Thread(CountUp)
            {
                Name = "Ishchi1"
            };
            Thread thread2 = new Thread(CountDown)
            {
                Name = "Ishchi2"
            };

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Main is finished");
            Console.WriteLine($"Main threadId: {Thread.CurrentThread.ManagedThreadId}");
        }
        public static void CountUp()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"CountUp: {i}, ThreadId: {Thread.CurrentThread.ManagedThreadId}, {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }
        public static void CountDown()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine($"CountDown: {i}, ThreadId: {Thread.CurrentThread.ManagedThreadId}, {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }
    }
}
