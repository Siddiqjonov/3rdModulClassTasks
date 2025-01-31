namespace UsingThreadToCountDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\ACer\Downloads\Telegram Desktop\Files";
            var files = Directory.GetFiles(directoryPath);


            foreach (var file in files)
            {
                if (file.Contains("result")) continue;
                new Thread(() => DisplayAndWrite(file)).Start();
            }

        }

        public static Object _lock = new Object();

        public static void DisplayAndWrite(string path)
        {
            FileInfo info = new FileInfo(path);

            var filePath = @"C:\Users\ACer\Downloads\Telegram Desktop\Files\result.txt";


            lock (_lock)
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                var allInfo = File.ReadAllText(path);
                int count = allInfo.Count(ch => char.IsDigit(ch));
                Console.WriteLine($"File: {info.Name}, Digits: {count}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                using (StreamWriter stream = new StreamWriter(filePath, true))
                {
                    var line = $"File: {info.Name}, Digits: {count}, ThreadId: {Thread.CurrentThread.ManagedThreadId}";
                    stream.WriteLine(line);
                }
            }
        }
    }
}
