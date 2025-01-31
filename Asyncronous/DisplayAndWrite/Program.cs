using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DisplayAndWrite
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string folderPath = @"C:\Users\ACer\Downloads\Telegram Desktop\Files";

            var files = Directory.GetFiles(folderPath);

            var tasks = files.Select(file => Task.Run(() => DisplayAndWriteFiles(file))).ToArray();

            //Task.WaitAll(tasks);

            // void can not be await

            await Task.WhenAll(tasks);
            Console.WriteLine("Finish");
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ToString());
        }
        public static Object _lock = new Object();

        public static void DisplayAndWriteFiles(string path)
        {
            var savePath = @"C:\Users\ACer\Downloads\Telegram Desktop\Files\result.txt";
            if (path == savePath) return;
            lock (_lock)
            {
                var count = File.ReadAllText(path).Count(ch => char.IsDigit(ch));
                var line = $"File: {path.Substring(path.LastIndexOf("\\") + 1)}, Digits: {count}, Thread ID: {Thread.CurrentThread.ManagedThreadId}";
                Console.WriteLine(line);
                using StreamWriter stream = new StreamWriter(savePath, true);
                stream.WriteLine(line);
            }
        }
    }
}
