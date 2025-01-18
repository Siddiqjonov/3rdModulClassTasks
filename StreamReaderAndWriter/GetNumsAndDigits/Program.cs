namespace GetNumsAndDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "text2.txt");
            FileCreate(path);
            StreamReaderInformation(path);
        }
        private static void FileCreate(string path)
        {
            if (!File.Exists(path))
            {
                List<string> lines = new();
                for (int i = 1; i <= 10; i++)
                {
                    lines.Add($"this is line number {i}");
                    File.WriteAllLines(path, lines);
                }
            }
        }
        public static void StreamReaderInformation(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                string? line = string.Empty;
                while (true)
                {
                    line = streamReader.ReadLine();
                    if (line == null) break;
                    Console.WriteLine(line);
                }
            }
        }
    }
}
